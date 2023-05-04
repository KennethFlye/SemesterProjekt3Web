﻿using Newtonsoft.Json;
using SemesterProjekt3Web.Models;
using System.Text;

namespace SemesterProjekt3Web.ApiAccess
{
    public class BookingAccess
    {
        readonly string baseUrl = "https://localhost:7155/api/bookings";
        readonly HttpClient client;

        public BookingAccess()
        {
            client = new HttpClient();
        }




        public async Task<bool> AddBooking(Booking res)
        {
            bool savedOk = false;
            var uri = new Uri(baseUrl);

            try
            {
                Console.WriteLine(1);
                //var response = await client.GetAsync(uri);
                Console.WriteLine(2);


                Console.WriteLine(3);
                var json = JsonConvert.SerializeObject(res);
                Console.WriteLine(4);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                Console.WriteLine(5);
                var postResponse = await client.PostAsync(uri, content);
                Console.WriteLine(postResponse.StatusCode);
                Console.WriteLine(6);
                if (postResponse != null && postResponse.IsSuccessStatusCode)
                {
                    savedOk = true;
                }



            }
            catch
            {
                savedOk = false;
            }
            Console.WriteLine(savedOk);
            return savedOk;
        }


        public async Task<Booking> GetBookingById(int id)
        {
            Booking book;


            string url = baseUrl + $"/{id}";
            var uri = new Uri(string.Format(url));


            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    book = JsonConvert.DeserializeObject<Booking>(content);
                }
                else
                {
                    book = null;
                }
            }
            catch
            {
                throw;
            }

            return book;
        }
        public async Task<IEnumerable<Seat>> GetSeatsByBooking()
        {
            List<Seat> seats;


            string url = baseUrl + $"/seats";
            var uri = new Uri(string.Format(url));


            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    seats = JsonConvert.DeserializeObject<List<Seat>>(content);
                }
                else
                {
                    seats = null;
                }
            }
            catch
            {
                throw;
            }
            return seats;
        }

    }
}