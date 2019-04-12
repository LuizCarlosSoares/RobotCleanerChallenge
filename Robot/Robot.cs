using System;
using System.Collections.Generic;
using Office;

namespace RobotCleaner
{
    public class Robot
    {


        private List<int> currenActions;
        private int total_actions = 0;


        public Robot()
        {

        }

        public Robot(int actions)
        {
            this.total_actions = actions;
        }

        public void Clean()
        {
            reset();
            for (int i = 0; i < total_actions; i++)
            {
                this.currenActions.Add(i);
            }

            if (currenActions.Count.Equals(total_actions))
            {
                this.CanMoveToNextPlace = true;
                reset();
            }

        }

        
        public void Clean(Graph<OfficeTile> room)
        {
            
            reset();
            for (int i = 0; i < total_actions; i++)
            {
                this.currenActions.Add(i);
            }

            if (currenActions.Count.Equals(total_actions))
            {
                this.CanMoveToNextPlace = true;
                reset();
            }

        }

        private void reset()
        {
            this.currenActions = new List<int>();
        }

        public bool CanMoveToNextPlace { get; set; }
    }
}
