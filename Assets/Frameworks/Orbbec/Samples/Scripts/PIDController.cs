using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIDController
{
        private float kp;  // ����������� ���������������� �����
        private float ki;  // ����������� ������������ �����
        private float kd;  // ����������� ���������������� �����
        public float setpoint;  // �������� ��������
        private float prevError;  // ���������� �������� ������
        private float integral;  // ����� ������

        public PIDController(float kp, float ki, float kd, float setpoint)
        {
            this.kp = kp;
            this.ki = ki;
            this.kd = kd;
            this.setpoint = setpoint;
            this.prevError = 0;
            this.integral = 0;
        }

        public float compute(float currentValue)
        {
            float error = setpoint - currentValue;
            integral += error;
            float derivative = error - prevError;

            float output = kp * error + ki * integral + kd * derivative;

            prevError = error;
            return output;
        }

        public void updateSetpoint(float setpoint)
        {
            this.setpoint = setpoint;
        }

}
