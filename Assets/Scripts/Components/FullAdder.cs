using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAdder : NewComponent
{
    public override void HandleInputs(object sender, EventArgs e)
    {
        // ��ȡ�����ź�
        int inputA = InputPins.GetValue(0);    // ���� A
        int inputB = InputPins.GetValue(1);    // ���� B
        int carryIn = InputPins.GetValue(2);   // ���� CarryIn

        // ���� Sum �� CarryOut
        int sum = inputA ^ inputB ^ carryIn;  // Sum = A XOR B XOR CarryIn
        int carryOut = (inputA & inputB) | (carryIn & (inputA ^ inputB));  // CarryOut = (A AND B) OR (CarryIn AND (A XOR B))

        // ��������ź�
        OutputPins.SetValue(0, sum);    // ��� Sum
        OutputPins.SetValue(1, carryOut); // ��� CarryOut
    }

    protected override void InitShape()
    {
        // �����������
        InputPins.AddPin(0, Type.BIT, -2, 2, false); // ���� A
        InputPins.AddPin(1, Type.BIT, -2, 0, false); // ���� B
        InputPins.AddPin(2, Type.BIT, -2, -2, false); // ���� CarryIn

        // ������״
        Debug.LogFormat("Body.AddRelativePosition start");
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                Body.AddRelativePosition(x, y);
            }
        }

        // ����������
        OutputPins.AddPin(0, Type.BIT, 2, 1); // ��� Sum
        OutputPins.AddPin(1, Type.BIT, 2, -1); // ��� CarryOut
    }
}
