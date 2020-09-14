using PLC;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace DataConcentrator
{
    public class Data_Concentrator
    {
        public static Context Context { get; set; }
        public static  PLCc PLC= new PLCc();
        public Dictionary<string, Thread> dAI = new Dictionary<string, Thread>();
        public Dictionary<string, Thread> dDI = new Dictionary<string, Thread>();
        public List<string> history = new List<string>();
       
        public void DIfunc(DI di)
        {
            while (true)
            {
                di.ValueDI =(Convert.ToInt32( PLC.GetDigitalInputValue(di.AddressDI)));

                Thread.Sleep(Convert.ToInt32(di.ScanTimeDI));
            }
        }

        public void DILoadT()
        {

            foreach (var di in Context.DIItems)
            {
                Thread threadDI = new Thread(() => DIfunc(di));
                dDI.Add(di.IdNameDI, threadDI);
                threadDI.Start();
            }
        }

    

        public void AIfunc(AI ai)
        {
            while (true)
            {
                ai.Active = "";
                ai.ValueAI = PLC.GetAnalogInputValue(ai.AddressAI);
               
                if (ai.Alarms.ToList()==null)
                {
                    ai.State = State.NO_LINKED_ALARM;
                    
                }

                if (ai.Alarms.ToList().Count == 0)
                {
                    ai.State = State.NO_LINKED_ALARM;
                   
                }
                else ai.State = State.REGULAR;
                if (ai.Alarms.ToList()!=null && ai.Alarms.ToList().Count!=0)
                {
                    if (ai.ActiveAlarms.ToList().Count != 0 && ai.ActiveAlarms.ToList() != null)
                    {

                        
                        foreach (var al in ai.Alarms.ToList())
                        {
                            foreach(var act in ai.ActiveAlarms.ToList())
                            {
                                if (al.OverUnder == "above")
                                {
                                    if (act.IdNameAlarm != al.IdNameAlarm)
                                    {

                                        if (ai.ValueAI > al.Limit)
                                        {
                                            al.time = DateTime.Now;
                                            string s = $"For tag {ai.IdNameAI}, there is/was an active alarm {al.IdNameAlarm} which started on {al.time} . ;";
                                            ai.History += s;
                                            ai.ActiveAlarms.Add(al);
                                        }
                                    }
                                    else
                                    {
                                        if (ai.ValueAI < al.Limit)
                                        {
                                            ai.ActiveAlarms.Remove(al);
                                        }
                                    }
                                }
                                if (al.OverUnder == "under")
                                {
                                    if (act.IdNameAlarm != al.IdNameAlarm)
                                    {
                                        if (ai.ValueAI < al.Limit)
                                        {
                                            al.time = DateTime.Now;
                                            string s = $"For tag {ai.IdNameAI}, there is/was an active alarm {al.IdNameAlarm} which started on {al.time} . ;";
                                            ai.History += s;
                                            ai.ActiveAlarms.Add(al);
                                        }
                                    }
                                    else
                                    {
                                        if (ai.ValueAI > al.Limit)
                                        {
                                            ai.ActiveAlarms.Remove(al);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach(var al in ai.Alarms.ToList())
                        {
                            if(al.OverUnder=="above")
                            { 
                                if (ai.ValueAI > al.Limit)
                                {
                                    ai.State = State.ALARM;
                                    al.time = DateTime.Now;
                                    string s = $"For tag {ai.IdNameAI}, there is/was an active alarm {al.IdNameAlarm} which started on {al.time} . ;";
                                    ai.History += s;
                                    ai.ActiveAlarms.Add(al);
                                }
                            }
                            if(al.OverUnder=="under")
                            {
                                if(ai.ValueAI<al.Limit)
                                {
                                    ai.State = State.ALARM;
                                    al.time = DateTime.Now;
                                    string s = $"For tag {ai.IdNameAI}, there is/was an active alarm {al.IdNameAlarm} which started on {al.time} . ;";
                                    ai.History += s;
                                    ai.ActiveAlarms.Add(al);
                                }
                            }
                        }
                    }
                }

                ai.Active = "";
                if (ai.ActiveAlarms.ToList() != null)
                {

                    if (ai.ActiveAlarms.ToList().Count != 0)
                    {
                        ai.State = State.ALARM;
                        foreach (var m in ai.ActiveAlarms.ToList())
                        {
                            if (!ai.Active.Contains(m.IdNameAlarm))
                            {
                                ai.Active += $"Alarm {m.IdNameAlarm} is active.\n";
                            }
                        }
                    }
                }
                if (ai.Alarms.ToList() == null)
                {
                    ai.Active = "No linked alarms";
                }

                else if (ai.Alarms.ToList().Count == 0)
                {
                    ai.Active = "No linked alarms";
                }
                else if (ai.ActiveAlarms.ToList() == null)
                {
                    ai.State = State.REGULAR;
                    ai.Active = "No active alarms.";
                }
                else if (ai.ActiveAlarms.ToList().Count==0)
                {
                    ai.State = State.REGULAR;
                    ai.Active = "No active alarms.";
                }

                Thread.Sleep(Convert.ToInt32(ai.ScanTimeAI));
            }
        }
        public void AILoadT()
        {
                
            foreach (var ai in Context.AIItems)
            {
                Thread threadAI = new Thread(() => AIfunc(ai));
                dAI.Add(ai.IdNameAI, threadAI);
                threadAI.Start();
            }
        }

        

        public void cAddAI(AI ai)
        {
          
            Context.AIItems.Add(ai);
            Context.SaveChanges();
            

            Thread threadAddAI = new Thread(() => AIfunc(ai));
            dAI.Add(ai.IdNameAI, threadAddAI);
            threadAddAI.Start();

        }

        public void cAddDI(DI di)
        {
            Context.DIItems.Add(di);
            Context.SaveChanges();

            Thread threadAddDI = new Thread(()=> DIfunc(di));
            dDI.Add(di.IdNameDI, threadAddDI);
            threadAddDI.Start();
        }

        public void cAddDO(DO doo)
        {
            Context.DOItems.Add(doo);
            Context.SaveChanges();
        }

        public void cAddAO(AO ao)
        {
            Context.AOItems.Add(ao);
            Context.SaveChanges();
        }

        public void cDeleteAI(AI ai)
        {
            
            dAI[ai.IdNameAI].Abort();
            dAI.Remove(ai.IdNameAI);
            Context.AIItems.Remove(ai);
            Context.SaveChanges();
        }

        public void cDeleteDI(DI di)
        {
            dDI[di.IdNameDI].Abort();
            dAI.Remove(di.IdNameDI);
            Context.DIItems.Remove(di);
            Context.SaveChanges();
            
        }
        public void cDeleteAO(AO ao)
        {
            Context.AOItems.Remove(ao);
            Context.SaveChanges();
        }

        public void cDeleteDO(DO doo)
        {
            Context.DOItems.Remove(doo);
            Context.SaveChanges();
        }

        public void cDeleteAlarm(Alarm al)
        {
            
            Context.AlarmItems.Remove(al);
            Context.SaveChanges();
        }

        public void cAddAlarm(Alarm al)
        {
            Context.AlarmItems.Add(al);
            Context.SaveChanges();
        }

        public void cAddAlarmToAI(AI ai)
        {
          
            Context.AIItems.AddOrUpdate(ai);
            Context.SaveChanges();
           
        }

      

        public void cDeleteAlarmFromAI(AI ai)
        {
            
            Context.AIItems.AddOrUpdate(ai);
            Context.SaveChanges();
         


        }

    }
}
