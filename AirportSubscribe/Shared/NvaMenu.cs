using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntDesign;
using AntDesign.Pro.Layout;
using Microsoft.AspNetCore.Components.Rendering;

namespace AirportSubscribe.Shared
{
    public class NvaMenu : RightContent
    {




        delegate double MyDelegate(double message);


        public double Ordinary(double price)
        {
            double price1 = 0.95 * price;
            Console.WriteLine("Ordinary Price : " + price1);
            return price1;
        }

        public double Favourable(double price)
        {
            double price1 = 0.85 * price;
            Console.WriteLine("Favourable Price : " + price1);
            return price1;
        }


        protected override void BuildRenderTree(RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Space>(0);



            //__builder.AddAttribute(1, "AA",new MyDelegate(Favourable));

            base.BuildRenderTree(__builder);
        }
    }
}
