using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame.Legacy
{
    public class FieldFactory
    {
        

        public FieldFactory()
        { }

        static public List<IField> CreateFields()
        {
            List<IField> fields = new List<IField>();

            for (int i = 0; i < 36; i++)
            {
                if (i % 2 == 0)
                {
                    if (i == 0)
                    {
                        fields.Add(new Field(Convert.ToUInt32(i), Field.Green));
                    }
                    else
                    {
                        fields.Add(new Field(Convert.ToUInt32(i),Field.Black));
                    }
                }
                else if (i % 2 != 0)
                {
                    fields.Add(new Field(Convert.ToUInt32(i), Field.Red));
                }
            }

            return fields;



        }
    }
}
