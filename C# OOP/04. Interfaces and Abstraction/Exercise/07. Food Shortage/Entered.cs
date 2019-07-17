using System;

namespace BirthdayCelebration
{
    public abstract class Entered
    {
        private string id;

        protected Entered(string id)
        {
            this.id = id;
        }

        public string Id
        {
            get => this.id;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Please Add Correct ID");
                }

                this.id = value;
            }
        }


    }
}
