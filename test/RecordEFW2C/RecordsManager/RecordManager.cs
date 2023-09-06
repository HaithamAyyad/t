﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using EFW2C.Common.Constants;
using EFW2C.Common.Enums;
using EFW2C.Records;

namespace EFW2C.Manager
{

    public class RecordManager
    {
        private bool _reSubmitted;
        private int _taxYear;

        public int TaxYear { get { return _taxYear; } set { _taxYear = value; } }

        List<RecordBase> _records;

        public RecordManager()
        {
            _records = new List<RecordBase>();
        }

        public void write()
        {
            foreach (var record in _records)
                record.Write();
        }

        public bool Verify()
        {
            if (!IsFeildsBelongToClass())
                return true;

            foreach (var record in _records)
            {
                if (!record.Verify())
                    return false;
            }

            return true;
        }

        public int GetRcwRecordsCount()
        {
            var count = 0;

            foreach (var record in _records)
            {
                if (record.RecordName == RecordNameEnum.RCW.ToString())
                    count++;
            }

            return count;
        }

        private bool IsFeildsBelongToClass()
        {
            foreach (var record in _records)
            {
                foreach (var field in record.Fields)
                {
                    if (record.ClassName.Substring(0, 3) != field.ClassName.Substring(0, 3).ToUpper())
                        throw new Exception($"{field.ClassName} doesn't belong to {record.ClassName}");
                }
            }

            return true;
        }

        public void AddRecord(RecordBase record)
        {
            _records.Add(record);
        }

        public void SetSubmitter(bool value)
        {
            _reSubmitted = value;
        }

        public bool IsSubmitter()
        {
            return _reSubmitted;
        }


        public RecordBase GetPrecedRecord(RecordBase sourceRecord, string recordName)
        {
            var pos = _records.Select((record, index) => new { Record = record, Index = index })
                              .FirstOrDefault(item => item.Record.RecordName == sourceRecord.RecordName)?.Index ?? -1;

            for (var i = pos - 1; i >= 0; i--)
            {
                if (_records[i].RecordName == recordName)
                {
                    return _records[i];
                }
            }

            return null;

        }
        public List<RecordBase> GetRecordsBetween(RecordBase first, RecordBase second, string recordName)
        {
            if (first == null || second == null)
            {
                return null;
            }

            int firstIndex = _records.IndexOf(first);
            int secondIndex = _records.IndexOf(second);

            if (firstIndex > secondIndex)
            {
                int temp = firstIndex;
                firstIndex = secondIndex;
                secondIndex = temp;
            }

            var recordsBetween = new List<RecordBase>();

            for(var i = firstIndex + 1; i < secondIndex; i++)
            {
                if (_records[i].RecordName == recordName)
                    recordsBetween.Add(_records[i]);
            }

            return recordsBetween;
        }

        public int GetTotal(string fieldClassName, RecordBase first, RecordBase second, string recordClassName)
        {
            if (first == null || second == null)
                return -1;

            var recordList = GetRecordsBetween(first, second, recordClassName);
            var sum = 0;

            foreach (var record in recordList)
            {
                var field = record.GetFields(fieldClassName.Replace(Constants.TotalStr, ""));
                if (field != null)
                {
                    Int32.TryParse(field.DataInRecordBuffer(), out int value);
                    sum += value;

                }
            }

            return sum;
        }

        public int GetRcoRecordsFeildsSum(string fieldClassName, RecordBase record)
        {
            var rceRecord = GetPrecedRecord(record, RecordNameEnum.RCE.ToString());

            if (rceRecord != null)
            {
                return GetTotal(fieldClassName, record, rceRecord, RecordNameEnum.RCO.ToString());
            }

            return 0;
        }
    }

}
