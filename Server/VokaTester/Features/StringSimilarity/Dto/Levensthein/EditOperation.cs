﻿namespace VokaTester.Features.StringSimilarity.Dto.Levensthein
{
    using System;

    public struct EditOperation
    {
        public EditOperation(char value, char oldValue, EditOperationKind operation)
        {
            Value = value;
            OldValue = oldValue;
            Operation = operation;
        }

        public EditOperationKind Operation { get; }

        public string OperationStr => Enum.GetName(typeof(EditOperationKind), this.Operation);

        public char Value { get; }
     
        public char OldValue { get; }}
}
