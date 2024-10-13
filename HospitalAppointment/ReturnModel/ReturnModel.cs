﻿namespace HospitalAppointment.ReturnModel
{
    public class ReturnModel<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
