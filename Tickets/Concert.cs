using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    internal class Concert
    {
        private string _BandName;
        
        // Property
        public string BandName
        {
            get { return _BandName; }
            set { _BandName = value; }
        }

        List<ConcertTicket> concert;

        // Constructor
        public Concert(string name)
        {
            BandName = name;
            concert = new List<ConcertTicket>();
        }

        // Methods
        public void AddConcertTicket(ConcertTicket ct)
        {
            if (ct.ConcertName != BandName)
            {
                throw new WrongConcertException("Sorry - this is the wrong concert");
            }
            else
            {
                concert.Add(ct);
            }
        }

        public void OutputAllSeats()
        {
            foreach (ConcertTicket ct in concert)
            {
                Console.WriteLine(ct.OutputStatus());
            }
        }
    }

    public class ConcertTicket
    {
        // Properties
        public string ConcertName { get; set; }
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }

        // Constructor
        public ConcertTicket(string concertName, string seatNumber, decimal price)
        {
            ConcertName = concertName;
            SeatNumber = seatNumber;
            Price = price;
        }

        // Method to output the status of the ticket
        public string OutputStatus()
        {
            return $"Concert: {ConcertName}, Seat: {SeatNumber}, Price: {Price:C}";
        }
    }

    public class WrongConcertException : Exception
    {
        public WrongConcertException(string message) : base(message)
        {
        }
    }

    // Example usage
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Concert concert = new Concert("The Rolling Stones");
                ConcertTicket ticket1 = new ConcertTicket("The Rolling Stones", "A1", 150.00m);
                ConcertTicket ticket2 = new ConcertTicket("The Beatles", "B1", 120.00m);

                concert.AddConcertTicket(ticket1);
                // This will throw an exception because the concert name does not match
                concert.AddConcertTicket(ticket2);

                concert.OutputAllSeats();
            }
            catch (WrongConcertException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
