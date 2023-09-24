using EFW2C.Common.Enums;
using EFW2C.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using test.RecordEFW2C.Common;

namespace EFW2C.Common.Helper
{
    internal class RecordsOrderHelper
    {
        public static bool VerifyRecordsOrder(List<RecordBase> records)
        {
            if (records == null || records.Count < 5)
                throw new Exception($"records list count can't be less than 5");

            if (records[0].RecordName != RecordNameEnum.Rca.ToString())
                throw new Exception($"First record must be {RecordNameEnum.Rca.ToString()}");

            if (records[records.Count - 1].RecordName != RecordNameEnum.Rcf.ToString())
                throw new Exception($"Last record must be {RecordNameEnum.Rcf}");

            if (GetRecordsCount(records, RecordNameEnum.Rca) > 1)
                throw new Exception($"number of {RecordNameEnum.Rca} must be one");

            if (GetRecordsCount(records, RecordNameEnum.Rcf) > 1)
                throw new Exception($"number of {RecordNameEnum.Rcf} must be one");

            var index = 1;
            while(index < records.Count - 1)
            {
                if (records[index].RecordName != RecordNameEnum.Rce.ToString())
                    throw new Exception($"index {index} record must be {RecordNameEnum.Rce}");

                var rceRecordGroup = FindRceGroup(records, index);

                if (!VerifyRceGroup(rceRecordGroup, index))
                    throw new Exception($"index {index} is not valid {RecordNameEnum.Rce} group");

                index += rceRecordGroup.Count + 1;
            }

            if (records[index].RecordName != RecordNameEnum.Rcf.ToString())
                throw new Exception($"Last record must be {RecordNameEnum.Rcf}");

            return true;
        }

        private static bool VerifyRceGroup(List<RecordBase> rceRecordGroup , int mainIndex)
        {
            if(rceRecordGroup != null && rceRecordGroup.Count > 1)
            {
                var index = 0;

                var rctCount = rceRecordGroup.Count(item => item.RecordName == RecordNameEnum.Rct.ToString());
                if (rctCount == 0)
                    throw new Exception($" Index = {index + mainIndex} {RecordNameEnum.Rce} must be have {RecordNameEnum.Rct}");

                if (rctCount > 1)
                    throw new Exception($" Index = {index + mainIndex} {RecordNameEnum.Rce} must be have only one {RecordNameEnum.Rct}");

                while (index < rceRecordGroup.Count - 1)
                {
                    if (rceRecordGroup[index].RecordName != RecordNameEnum.Rcw.ToString())
                        throw new Exception($" Index = {index + mainIndex + 1} must be {RecordNameEnum.Rcw}");

                    do
                    {
                        var rcwRecordGroup = FindRcwGroup(rceRecordGroup, index);

                        if (!VerifyRcwGroup(rcwRecordGroup, index + mainIndex))
                            throw new Exception($"index {index + mainIndex + 1} is not valid {RecordNameEnum.Rcw} group");

                        index += rcwRecordGroup.Count + 1;

                    } while (rceRecordGroup[index].RecordName == RecordNameEnum.Rcw.ToString());


                    if (rceRecordGroup[index].RecordName != RecordNameEnum.Rct.ToString())
                        throw new Exception($"index {index + mainIndex + 1} must be {RecordNameEnum.Rct}");

                    if (rceRecordGroup.Count == index + 1)
                        break;

                    if (rceRecordGroup.Count - 3 >= index)
                    {
                        index++;
                        if (rceRecordGroup[index].RecordName != RecordNameEnum.Rcu.ToString())
                            throw new Exception($"index {index + mainIndex + 1} must be must be either {RecordNameEnum.Rcu} or {RecordNameEnum.Rcv} or {RecordNameEnum.Rce}");

                        index++;
                        if (rceRecordGroup[index].RecordName != RecordNameEnum.Rcv.ToString())
                            throw new Exception($"index {index + mainIndex + 1} must be must be either {RecordNameEnum.Rcv} or {RecordNameEnum.Rce}");
                    }
                    else
                    {
                        if (rceRecordGroup.Count - 2 >= index)
                        {
                            index++;
                            if (rceRecordGroup[index].RecordName != RecordNameEnum.Rcu.ToString() &&
                               rceRecordGroup[index].RecordName != RecordNameEnum.Rcv.ToString())
                                throw new Exception($"index {index + mainIndex + 1} must be either {RecordNameEnum.Rcu} or {RecordNameEnum.Rcv} or {RecordNameEnum.Rce}");
                        }
                    }

                    if (rceRecordGroup.Count - 1 != index)
                        throw new Exception($"index {index + mainIndex + 2} must be either {RecordNameEnum.Rce} or {RecordNameEnum.Rcf}"); ;
                }

                var rcoCount = rceRecordGroup.Count(item => item.RecordName == RecordNameEnum.Rco.ToString());

                if (rcoCount == 0)
                {
                    if (rceRecordGroup.Count(item => item.RecordName == RecordNameEnum.Rcu.ToString()) > 0)
                    {
                        var pos = rceRecordGroup.FindIndex(item => item.RecordName == RecordNameEnum.Rcu.ToString());
                        throw new Exception($"index {pos + mainIndex  + 1} {RecordNameEnum.Rcu} must have {RecordNameEnum.Rco}");
                    }
                }
                else
                {
                    if (rceRecordGroup.Count(item => item.RecordName == RecordNameEnum.Rcu.ToString()) == 0)
                    {
                        var pos = rceRecordGroup.FindIndex(item => item.RecordName == RecordNameEnum.Rco.ToString());
                        throw new Exception($"index {pos + mainIndex + 1} {RecordNameEnum.Rco} must have {RecordNameEnum.Rcu} after {RecordNameEnum.Rct}");
                    }
                }

                var rcsCount = rceRecordGroup.Count(item => item.RecordName == RecordNameEnum.Rcs.ToString());

                if (rcsCount == 0)
                {
                    if (rceRecordGroup.Count(item => item.RecordName == RecordNameEnum.Rcv.ToString()) > 0)
                    {
                        var pos = rceRecordGroup.FindIndex(item => item.RecordName == RecordNameEnum.Rcv.ToString());
                        throw new Exception($"index {pos + mainIndex + 1} {RecordNameEnum.Rcv} must have {RecordNameEnum.Rcs}");
                    }
                }
                else
                {
                    if (rceRecordGroup.Count(item => item.RecordName == RecordNameEnum.Rcv.ToString()) == 0)
                    {
                        var pos = rceRecordGroup.FindIndex(item => item.RecordName == RecordNameEnum.Rcs.ToString());
                        throw new Exception($"index {pos + mainIndex + 1} {RecordNameEnum.Rcs} must have {RecordNameEnum.Rcv} after {RecordNameEnum.Rct}");
                    }
                }

                return true;
            }

            return false;
        }

        private static bool VerifyRcwGroup(List<RecordBase> rcwRecordGroup, int mainIndex)
        {
            if (rcwRecordGroup.Count == 0)
                return true;

            if (rcwRecordGroup.Count == 1)
            {
                if (rcwRecordGroup[0].RecordName != RecordNameEnum.Rco.ToString() &&
                    rcwRecordGroup[0].RecordName != RecordNameEnum.Rcs.ToString())
                    throw new Exception($"index {1 + mainIndex} must be either {RecordNameEnum.Rco} or {RecordNameEnum.Rcs} or {RecordNameEnum.Rct} or {RecordNameEnum.Rcw}");
            }

            if (rcwRecordGroup.Count >= 2)
            {
                if (rcwRecordGroup[0].RecordName != RecordNameEnum.Rco.ToString())
                    throw new Exception($"index {2 + mainIndex} must be must be either {RecordNameEnum.Rco} or {RecordNameEnum.Rcs} or {RecordNameEnum.Rct} or {RecordNameEnum.Rcw}");

                if (rcwRecordGroup[1].RecordName != RecordNameEnum.Rcs.ToString())
                    throw new Exception($"index {3 + mainIndex} must be {RecordNameEnum.Rcs} or {RecordNameEnum.Rct} or {RecordNameEnum.Rcw}");
            }

            if (rcwRecordGroup.Count > 2)
                throw new Exception($"index {4 + mainIndex} must be either {RecordNameEnum.Rcw} or {RecordNameEnum.Rct}");

            return true;
        }

        private static List<RecordBase> FindRceGroup(List<RecordBase> records, int index)
        {
            var result = records
                   .Skip(index + 1) 
                   .TakeWhile(record => record.RecordName != RecordNameEnum.Rcf.ToString() &&
                              record.RecordName != RecordNameEnum.Rce.ToString())
                   .ToList(); 

            return result;
        }

        private static List<RecordBase> FindRcwGroup(List<RecordBase> records, int index)
        {
            var result = records
                   .Skip(index + 1) 
                   .TakeWhile(record => record.RecordName != RecordNameEnum.Rct.ToString() &&
                              record.RecordName != RecordNameEnum.Rcw.ToString())
                   .ToList(); 

            return result;
        }

        private static int GetRecordsCount(List<RecordBase> records, RecordNameEnum recordName)
        {
            return records.Count(item => item.RecordName == recordName.ToString());
        }
    }
}
