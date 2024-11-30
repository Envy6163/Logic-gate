using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using System.Xml.Serialization;

public abstract class NewComponent : MonoBehaviour
{
    public Body Body { get; } = new();
    
    public InputPinList InputPins { get; } = new();
    public OutputPinList OutputPins { get; } = new();
    public bool NoInputWires => InputPins.NoWiresConnected;
    public Vector2Int CenterPosition { get; private set; }
    public List<Vector2Int> PositionsOfBody { get; } = new();//�������еľ���λ�ã���������֮��Ĳ��֣��������ڷ���Ԫ������ʱ����ͻ��
    public List<Vector2Int> PositionsOfPins { get; } = new();//�������еľ���λ�ã����������������ţ��������ڷ���Ԫ��ʱ����ͻ��
    public void SetPositions(Vector2Int centerPos)          //���������������ø������ֵ�����
    {
        PositionsOfBody.Clear();
        PositionsOfPins.Clear();
        CenterPosition = centerPos;
        foreach (var pos in Body.RelativePositions)
        {
            PositionsOfBody.Add(pos + centerPos);
        }
        foreach (var pos in InputPins.RelativePositions)
        {
            PositionsOfPins.Add(pos + centerPos);
        }
        foreach (var pos in OutputPins.RelativePositions)
        {
            PositionsOfPins.Add(pos + centerPos);
        }
    }
    //˳ʱ����ת90�ȣ�������Ϸ����
    public void Rotate()
    {
        InputPins.Rotate();
        OutputPins.Rotate();
        Body.Rotate();
        transform.Rotate(0, 0, -90);
    }
    public virtual void HandleInputs(object sender, EventArgs e)
    {
        // ������봦���ض���������ţ�����ʹ�� GetPin ����ȡ
        for (int i = 0; i < OutputPins.Count; i++)
        {
            OutputPin pin = OutputPins.GetPin(i);  // ��ȡ�� i ���������
            pin.Value = pin.Value;  // ���������Ҫ�������ŵ�ֵ
        }
    }
    protected abstract void InitShape(); 
    public void SubscribeToInputs()
    {
        InputPins.SubscribeToWires(HandleInputs);
    }
    public void Disconnect()
    {
        InputPins.Disconnect(HandleInputs);
    }
    private void Awake()
    {
        InitShape();
    }
    private void OnDestroy()
    {
        Disconnect();
    }
}
