using Hierarchy.POCOs;
using Operations;

namespace ProjectTest
{
    public class UnitTest4
    {
        private RollingUp _rollup;

        public UnitTest4(RollingUp rollup)
        {
            _rollup = rollup;
        }

        [Fact]
        public void Test4()
        {
            Dictionary<string, (Variant variant, Product product, decimal price)> input = new Dictionary<string, (Variant, Product, decimal)>();
            input.Add("G1", (variant: new Variant() { ID = "V1" }, product: new Product() { ID = "P1" }, price: 50m));
            input.Add("G2", (variant: new Variant() { ID = "V1" }, product: new Product() { ID = "P1" }, price: 70m));
            input.Add("G3", (variant: new Variant() { ID = "V2" }, product: new Product() { ID = "P1" }, price: 100m));
            input.Add("G4", (variant: new Variant() { ID = "V2" }, product: new Product() { ID = "P1" }, price: 90m));
            var result = _rollup.RollUp(input);
            Dictionary<string, decimal> expected = new Dictionary<string, decimal>();
            expected.Add("P1", 50m);
            expected.Add("V2", 90m);
            expected.Add("G2", 70m);
            expected.Add("G3", 100m);
            Assert.Equal(expected, result);
        }
    }
}
