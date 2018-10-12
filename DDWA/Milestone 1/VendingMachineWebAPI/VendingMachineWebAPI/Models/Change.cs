namespace VendingMachineWebAPI.Models
{
    public class Change
    {
        private const decimal QUARTER = 0.25M;
        private const decimal DIME = 0.10M;
        private const decimal NICKEL = 0.05M;
        
        public int Quarters { get; set; }
        public int Dimes { get; set; }
        public int Nickels { get; set; }
        public int Pennies { get; set; }

        public Change(decimal amount)
        {
            Quarters = (int)(amount / QUARTER);
            amount -= Quarters * QUARTER;
            Dimes = (int)(amount / DIME);
            amount -= Dimes * DIME;
            Nickels = (int)(amount / NICKEL);
            amount -= Nickels * NICKEL;
            Pennies = (int)(amount * 100);
        }
    }
}