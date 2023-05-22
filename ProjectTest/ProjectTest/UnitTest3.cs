using Hierarchy.POCOs;
using Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest
{
    public class UnitTest3
    {
        private RollingUp _rollup;

        public UnitTest3(RollingUp rollup)
        {
            _rollup = rollup;
        }

        [Fact]
        public void Test3()
        {
            Dictionary<string, (Variant variant, Product product, decimal price)> input = new Dictionary<string, (Variant, Product, decimal)>();
            input.Add("G1", (variant: new Variant() { ID = "V1" }, product: new Product() { ID = "P1" }, price: 50m));
            input.Add("G2", (variant: new Variant() { ID = "V1" }, product: new Product() { ID = "P1" }, price: 100m));
            input.Add("G3", (variant: new Variant() { ID = "V2" }, product: new Product() { ID = "P1" }, price: 100m));
            input.Add("G4", (variant: new Variant() { ID = "V2" }, product: new Product() { ID = "P1" }, price: 100m));
            var result = _rollup.RollUp(input);
            Dictionary<string, decimal> expected = new Dictionary<string, decimal>();
            expected.Add("P1", 50m);
            expected.Add("V2", 100m);
            expected.Add("G2", 100m);
            Assert.Equal(expected, result);
        }
    }
}
