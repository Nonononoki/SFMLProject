using SpaceX.component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceX.bossWindow.boss.bossAttackPattern
{
    class BossPatternChanger : ILogicComponent
    {
        public Queue<IBossAttackPattern> PatternList { set; get; }
        public Boss Boss { set; get; }
        public int MaxHP { set; get; }
        public int State { set; get; }
        public int ListSize { set; get; }
        public IBossAttackPattern CurrentPattern { set; get; }

        public BossPatternChanger(Queue<IBossAttackPattern> PatternList, Boss Boss)
        {
            this.PatternList = PatternList;
            this.Boss = Boss;
            this.MaxHP = Boss.Health;
            ListSize = PatternList.Count;

            State = 0;
            CurrentPattern = PatternList.Peek();
            Boss.AddComponent(PatternList.Dequeue());
         }

        public void ChangePattern(int Health)
        {
            //only change pattern if HP reaches certain percentage

            //get percentage
            float p = ((float)Health / (float)MaxHP);

            //get value for next pattern
            int nextState = State + 1;
            float p2 = 1f - ((float)nextState / (float)ListSize);

            if(p <= p2 /*&& PatternList.Any()*/)
            {
                if (State < ListSize && PatternList.Any())
                {
                    State++;
                    Boss.RemoveComponent(CurrentPattern);
                    CurrentPattern = PatternList.Peek();
                    Boss.AddComponent(PatternList.Dequeue());
                }
            }
            
        }

        public void Destroy()
        {
            //throw new NotImplementedException();
        }

        public void Update()
        {
            //throw new NotImplementedException();
        }
    }
}
