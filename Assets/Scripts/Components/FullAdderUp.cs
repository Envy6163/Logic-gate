/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAdderUp : NewComponent
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

        // �������־��Zero Flag��
        int zeroFlag = (sum == 0) ? 1 : 0;

        // ������ű�־��Sign Flag�� - ͨ���鿴 sum �ķ���λ
        int signFlag = (sum < 0) ? 1 : 0;

        // ���������־��Overflow Flag��
        // ���������A �� B ������ͬ���� Sum �ķ��Ų�ͬ
        int overflowFlag = ((inputA ^ inputB) & (inputB ^ sum)) >> 31;  // (A XOR B) AND (B XOR Sum) ����Ƿ����

        // ��������ź�
        OutputPins.SetValue(0, sum);           // ��� Sum
        OutputPins.SetValue(1, carryOut);      // ��� CarryOut
        OutputPins.SetValue(2, zeroFlag);      // ��� Zero Flag
        OutputPins.SetValue(3, overflowFlag);  // ��� Overflow Flag
        OutputPins.SetValue(4, signFlag);      // ��� Sign Flag
    }

    protected override void InitShape()
    {
        // �����������
        InputPins.AddPin(0, Type.BIT, -2, 2, false);  // ���� A
        InputPins.AddPin(1, Type.BIT, -2, 0, false);  // ���� B
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
        OutputPins.AddPin(0, Type.BIT, 2, 2);   // ��� Sum
        OutputPins.AddPin(1, Type.BIT, 2, 1);  // ��� CarryOut
        OutputPins.AddPin(2, Type.BIT, 2, 0);   // ��� Zero Flag
        OutputPins.AddPin(3, Type.BIT, 2, -1);  // ��� Overflow Flag
        OutputPins.AddPin(4, Type.BIT, 2, -2);   // ��� Sign Flag
    }
}*/

//�����Ϊ1λʱ�����´��룡

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAdderUp : NewComponent
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

        // �������־��Zero Flag��
        int zeroFlag = (sum == 0) ? 1 : 0;

        // ������ű�־��Sign Flag�� - ����1λ�ӷ��������ű�־��sum��ͬ
        int signFlag = sum;  // Sum == 1 -> positive (sign = 1), Sum == 0 -> negative (sign = 0)

        // ���������־��Overflow Flag��
        // ���������A �� B ������ͬ���� Sum �ķ��Ų�ͬ
        int overflowFlag = ((inputA == inputB) && (sum != (inputA ^ inputB))) ? 1 : 0;  // ��� A �� B ��ͬ���� Sum �����ǵĺͲ�ͬ�������

        // ��������ź�
        OutputPins.SetValue(0, sum);           // ��� Sum
        OutputPins.SetValue(1, carryOut);      // ��� CarryOut
        OutputPins.SetValue(2, zeroFlag);      // ��� Zero Flag
        OutputPins.SetValue(3, overflowFlag);  // ��� Overflow Flag
        OutputPins.SetValue(4, signFlag);      // ��� Sign Flag
    }

    protected override void InitShape()
    {
        // �����������
        InputPins.AddPin(0, Type.BIT, -2, 2, false);  // ���� A
        InputPins.AddPin(1, Type.BIT, -2, 0, false);  // ���� B
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
        OutputPins.AddPin(0, Type.BIT, 2, 2);   // ��� Sum
        OutputPins.AddPin(1, Type.BIT, 2, 1);   // ��� CarryOut
        OutputPins.AddPin(2, Type.BIT, 2, 0);   // ��� Zero Flag
        OutputPins.AddPin(3, Type.BIT, 2, -1);  // ��� Overflow Flag
        OutputPins.AddPin(4, Type.BIT, 2, -2);  // ��� Sign Flag
    }
}
