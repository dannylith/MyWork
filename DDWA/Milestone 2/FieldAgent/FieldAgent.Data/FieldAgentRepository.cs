using FieldAgent.Domain.Repositories;
using FieldAgent.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Data
{
    public class FieldAgentRepository : IFieldAgentRepository
    {
        private static string filePath = @"C:/Test/fieldAgents.txt";
        private static string filePathSeed = @"C:/Test/fieldAgentsSeed.txt";
        static FieldAgentRepository()
        {
            //Files should be in the root of the project, may need to move them to the specified path
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.Copy(filePathSeed, filePath);
        }
        //private static List<Agent> agents = new List<Agent>();

        //static FieldAgentRepository()
        //{

        //    agents.Add(new Agent {
        //        FirstName = "James",
        //        MiddleName = "",
        //        LastName = "Bond",
        //        PicturUrl = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxAPEBAPEBAPDw8PDw8PDw8PDw8NDw8PFRUWFhURFRUYHSggGBolGxUVITEhJSkrLi4uFx8zODMtNygtLisBCgoKDg0OFhAQFSsdHR0rLSstLS0tLS0tKystLS0rLSstLSstLSstLS0tKystLS0tLS0tLS0rLSs3LS0tNy0rN//AABEIALcBEwMBIgACEQEDEQH/xAAcAAABBQEBAQAAAAAAAAAAAAACAAEDBAUGBwj/xAA5EAACAgEDAgQEBAQEBwEAAAAAAQIDEQQSIQUxBhNBUSJhcYEUMkKRB1KhsSNywfAzQ3OSstHhFf/EABgBAQEBAQEAAAAAAAAAAAAAAAABAgME/8QAHREBAQEBAAMBAQEAAAAAAAAAAAERAgMSITFBIv/aAAwDAQACEQMRAD8A8YHGHAcQhwEIQSQDYCSEkGogCkGohKIaiACiEokigGoARqISiSqASgXE1EoBKJMoD7QIdo+0l2i2lRFtH2hy4KdtzfC4Jq4kstiuO79iCV8vkvtkVNE5tRjFyb7JLLNSnw7Y+Z/Avb1MXrGpzb+MuOra7pP7dmT02qWU++Mrt2NaXh6O1tSbaWfT0MW/TNZ900n7idS/i3mz9TZXZNP6CaKcFyvb1Zbqy45ZrWSwNgPAwAYGwHgYAMCwFgfAEeBYDwNgAcCCwIDNwOJDpAJIdIkqryX6unN+gGckEoly7RuJWzgBKJJGIoyRNBoAYwJI1ksEiWNZrEQxrDUCwqg1WXE1XUAthYUB9gw1AoDbSxsGcS4moNo20maBaCoLeFn1J+hdJeqslHiMYxTlLHv2X9GC4nYeB6F5c36uf9ksHLyfI6eObcaPTeh10xShBZxzLHP7ga/p79v9Toa5JfP+xV6hN92kv9+x5q9kcfZU4fIyOpaTKbj35z2/Y6bqU4NZWM+yMfVxWMrlc/cc9Yx3zK5Jxftzz++TWjSp1Zjl7U1wuPzLl+3f+hQ1le2XHZ8/c2PDstm6TwoxW+cpPEYQ5Ty/ftg7W/NeeT7jGlHHD4+vDGL/AFWGZqyKeyxJxbTWcJZ4a455+5RaOk+xmzACwEMEDgcfAwDNDYCGwAIwQgM1IOER4xJq4AXtBp8m7RXhFfpNS4D1+ocGbjNTajS7l2OY6jptrOu6dbviYnXYYbFhHPLI6bDUkEpIw0GNskSR1c0JTQSlEaJIdRkjS0WuU+HwzKTiHFxXKeBOkx0O0W0xoXz9JE1WrsXd5N+0TGk4guJW/FvbnPxfy4D0+qjuTsUseqi8D2hgmgWgt0W5bd23Pw7nmWBNFQGDr/Bcl5ck3hKbz+yOSLel1O2Dh8WXJYjF4TbaW6T9kc/JNjr47nT0q63Ed0fixx9Pr+5xtvVNVqrvKrXDm4LGFmXt/wDTW8NU2VxujOzzFKL2vnCaz8uPpyN0rSL4o+k5ue5fmTfc81+V6v2OelG2c4wnTJSctqzLv3zxhexp/wD5Eoxk5cY7RZ1ek6VXB7nH4l+p5b+xQ63L4WkTo5jzTqdft6P7mr4aolKzS1zinCdll+JNf4jrTSjj1afOPoUNfH4pfU2eg6RSqrv3ONlEro1Sz8EJN5W5ff8A3g3b8Y5n+geLoKuNdXtbdJP12va1/wCX9DmDY8Rap2WRTedkMbv55PmUvuzIZ18c/wAxy8t3uhaGCY2DbkYYfAsEUwzCGAHAhxAV4VliuosU6fJfo0hqRm1J0ue3Bo6jSRs5Ka0jjyizVc49zeIm0+nVaZzfXbctmxrdc8YSOZ1cZzfZmasZzEW1op+wcen2ezM41qiLk0Y9Ksf6WTR6LY/QZU2MjLHUizq9JKt4aKnJFXqbsIN6j2KHI1beeSYNGOr+RI9bx2yUeEMp4fOMDBpaHXbpKO3GfmabRiaayKknlJLlmvVqYT7P7G+WaJh6ezZOM/5ZJ/XHdAsY0R6l0+qEowUZR2yTlnssPt/c5vW6yOntt8u2MrI/HCtfE+O+UvQr+GOobovTz5xnYsuLcfk16r+zN78Dp9PCLXl05nGblOT3Tbj7yy5YPH1zlx7eevafG3HUSlXGWNspQjNxfEllZw17rJh6xKTbbyTW3KxYgrG1yrNrgvtuw2ZXUdS65x3fr4ftkzWvxz3WtLjczN0F222lwbXlb7JpSajJxknGTXbu3+xo+JtbiLXq+yKPSNBJU2XyWHZhRXr5ffP3f9jU+Ryv3pL4pknqrWlhSaml/mW7/UyDrep9Gnbo9Rru8qa6JQh2cqq44usb9ueP+mzj6LVNZ7fI9HP48/X6cbATQjTIRmER2MlU0pgOYwxFLcIEcDqtNozTo0Zb0+mL1dJ6JHLVOGlXsNLp8WaarH2FRjy6TF9xl0mtehsOAEokNZi6fWv0oeOkgv0ovyiBtKKnkJeiAlAuSiQyiBz/AFbpHmvcmZMvDc/dHYziQziZvMrUuPOdXXKuTg+6K+M8nQeJdLixSxxIw5QwcLMdEM0xQQ9jyNAA2iSmTTTyCSRhlZIroKLN0U/kEzN6ffj4WRajWycmk/hzxjjKNzr4zn1s0XOuUZxeJReUdr0aStcZUwqzjm23dOcX6pL3+55hLVTS7s1vDPiazSTcsOcJd455T/mRz7nt+Ovj79a9Ss0cq1lzcpS/U1t+y9jkPFGurrUVndNPhGX1HxtfdJbUorOI55b9k+eDE1MpOfmaiSlOTy4wlCySX2e1fd/Y5Tx/frp15Pnxr9F6Vb1C+OYucc5cUm8pen3Z6lHwqoR3WpPavhqX5V/na7/RHD+Fv4lw0EVUun1qntKULpPUyf8ANKcliX0SivbB0fiT+JumejVumTeotbhGmxYdUkk5Sn7xWV27v746zif1x97/ABzvi7r/AOFru00Xus1MJQkuPhrktrbS7LHCX/o8+0uoUeH2K+r1M7Zyssk5zm3KUpcttkOTTLdTyIx6r3Hs2Xatan+ZfdF1MWiCwnjJPtyRXIUiJgsdgsikIQgPWaIFqECPTxLcYnocQKAnEn2gyRRXlEikizJEU0BXkgGiZojYASRDJFiaIZgV5IhlEsSBhjcs9s8kqxF4g6TK2FXlQUsL4jjut9B1NS3Sraj7x5PW9FFY+H9vkP1K2Cg1JJ/Jni9q9fpK8F8h+zLug6RZd+VcL1PSodNok29kf2Dq0cY8Rio/REvkWeJwUvC9iWWw6Onxp/PmX9j0OOl3LBzXijSKqGTPvat4k+ua1dEM7o8fIytRHbL+pNbc2yPUrhS+x2nxxqKc9z+SJFFY74KrZNu9ePuaZdF4M8N2dV1MtNXZXU40zu32QlKOIyhHbher3r9gfFvhi7peo8i5ZTSlVdGLjXdHCy4/NPhruvus95/BHU6PT1au+6+qq6dsKUpyUWqYxUsrPvKb/wC1HeeIesdM1FDpvt0t8JyglCUoSw20t69mk28ouD5pss5IpzNjxnpdJRrbqtFOdmng0lKclP43zKMZJcxWUsvnh8swmyBDZGyNkB8hxmRibAtQvx2eCwtZnvz8+xm5HUgNFWp+o5nZJ6LfR9vQCzkQwgPZKC0ijTaW4TPQ5LCAYosaTACSIpIklIjmyoikiGRK2RyAaZBMmmyCbAikRSDnIimyK6PpWo+BS9VwWXbC3KnFS/ozJ6HqlzD1XK+ZrRUJN5WPpweLuZa9vF2K8tBT+nMfoxR6VFvO9kv4B5+GefkwvLshy1n6HNsFuiUVxk4Txpdlbc+p3lmvwnuieVeLdX5l8kuyLzNrPdyMWMU+5PsUouPv2+pWRLFnZwZ9lbi8NAHS9J01OotjVfYqoSjJb8ZxL9P9TL630izSWyqsXbmMlypxfaSLKlinTPBJK5kCGmyoZyBbEMwGYkMOA6QsBVkjQEAg5RBaAZMJMFBKOQLyYhhAepUX9i9Vac3p9V2NHT6o7uTejaJ2GZHUknnAXJWAykU/NHdpRM5EUpEUrCOVhUTSmQTmDKwgnYA85EU5ASsIpWEVNXe4SUk+UdH0vqcLeJcM5GVhn9Xskq3OLalBqSaeGvQ5eTiWOnHd5erw0r7wlle3qHCWOJ5PNvDvjS2tRjqM4fEbO2fqdhqPFem8pyclJpdk02zzWY9M61a69q66a5S4awzxnWWb7JS922a/Xeuz1Mml8MM8LJkxqya5n9Y761EoCafp9MlzSUxdkIzb8vfDzXHuqty3NfPGTrfFGm6Zu83RbvKeIQre7KaXM8vvk68865W44WvfB7vX0ysp/Q7bpfS1qNHKy9Ssc3shKfeMV7fcrdC6StZZHTwUrJTTy/SmGeZM9U1PRI16eNUI4jXFRj9vUvrGdfPnVtA9PbKvOUuU/kzOZt+Jbd2qu9lJx/bgyHEy0hBYUkCAhhNiAkrDS+oEQsgO0M0PkTADA8XyvqhMZd19QLY4ORAdLTqC7Tqvmc/C4sV3m5WMdJVqi1DVHNV6onjq/ma1MdCtQJ6gw46v5h/iy6Nd3kbvMv8AFDPUjUabu4IZ3FD8SRvUDVXpWkUrSm7wHeTTFuVgEplR3Au4mribUKM1iSTRXq00Idl+7yM7QfNIqWUI+yGdafGO/HBF5h1XgHoU9VqI2uDdFLUpPHwymu0QJH4U1OjoUnGF0bNtk4Y5Sx+Vsq9C8O6rVyVVdfwyk3vf5KI57v3+h7JPRqafmNRi327v6F7p6qpjsqhGEfksZfuyRaqeFfClHTqtlfxWS5ttf5pv/RfIqePusV6DR2WPG+ScKo+spvsbup6pXVCVlklGMU2236Hzz/EDxVLqWpcllUV5jTD5es382ByGok5NyfLk22/dsiyTTRAzKhnEiZNkGccgQiEICSAaRHUyUBkJjT9x+6ABh0x9f2Isk8FhASZEBkQFlTDVpV3DqQF1XhrUFDcEpl0xoR1IX4ozt4+8amNH8SL8SZ+8W8aY0PxILvKKmLeNMXfPGdxT3i3jTFvzhvOKu8W4aYs+aLzCtvFuGmLddqys8rKyvdH0V4c1+ls01X4TYqVFLbDja/VNe581KRr+HfEV+hsVlUvhb+Otv4Jr5/P5jVeudf8AFT0erdd0F5M8eVKOc49WzqtM4zjGcZ5jJKSa9mcdXfo+v6Zr8tsfT/mUz9/oc91vxFb0nTR6dXartQlLzLfSqD/LFfM0gP4o+KPMn+Dpl/hw/wCNJP8ANL+U84chrLHJttttttt8tv3I2yWqJkM0HkZkELBySSRG0QKQDgFPhjxAiJ4MbCFgB/kAnh/0E5fuNN+vuAUFyyTIEPcIBCGyOA+RZBHyAWR8gZFkA8j5AyLIEmRbiPI+QDyLIGRZAk3DZAyLIB5H3EeRZAk3DZAyLIEmR9xHkWQLvTOpXaWxXUWSrmk1leqfo16kGp1MrJSnOTlOTcpSby22QNjMA1IfJG2FLK+YBZGBUh0AmBjkNgw7gDeviQ0UFf3QmgI3wJsexDJADZ3ByG+WhtvIEkVwONkQCHGEAsiyIQDiEIBCyOIBZFkQgFkWRCAQhCAQhCAcYQgFkfIwgELIhAMmE2MIAQ62/UQgCY0BCAG/0HiIQA3DREIBqll5G9WOIBCEIBCEID//2Q==",
        //        BirthDate = DateTime.Parse("January 1, 1960"),
        //        Height = 70,
        //        Identifier = "agent-1",
        //        Agency = "FBI",
        //        ActivationDate = DateTime.Parse("January 1, 1980"),
        //        SecurityClearance = "Confidential",
        //        IsActive = false
        //    });

        //    agents.Add(new Agent
        //    {
        //        FirstName = "Fulvia ",
        //        MiddleName = "M",
        //        LastName = "Scandwright",
        //        PicturUrl = "http://www.bostonherald.com/sites/default/files/styles/gallery/public/media/2018/02/19/022118annihilation3.jpg",
        //        BirthDate = DateTime.Parse("11/23/1982"),
        //        Height = 68,
        //        Identifier = "SC-123-REX9",
        //        Agency = "CIA",
        //        ActivationDate = DateTime.Parse("04/12/2002"),
        //        SecurityClearance = "Secret",
        //        IsActive = true
        //    });
        //}

        public IEnumerable<Agent> All()
        {
            List<Agent> agents = new List<Agent>();

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] columns = line.Split(',');
                        if (columns.Length == 11)
                        {

                            agents.Add(new Agent
                            {
                                FirstName = columns[0],
                                MiddleName = columns[1],
                                LastName = columns[2],
                                PicturUrl = columns[3],
                                BirthDate = DateTime.Parse(columns[4]),
                                Height = int.Parse(columns[5]),
                                Identifier = columns[6],
                                Agency = columns[7],
                                ActivationDate = DateTime.Parse(columns[8]),
                                SecurityClearance = columns[9],
                                IsActive = bool.Parse(columns[10])
                            });
                        }
                    }
                }
                return agents;
            }
            return null;
        }

        public void Add(Agent agent)
        {
            var agents = All().ToList();
            agents.Add(agent);
            WriteAll(agents);
        }

        public Agent FindByIdentifier(string id)
        {
            return All().FirstOrDefault(a=>a.Identifier == id);
        }

        public void Edit(Agent agent, string oldIdentifier)
        {
            var agents = All().ToList();
            agents.Remove(agents.First(a=>a.Identifier == oldIdentifier));
            agents.Add(agent);
            WriteAll(agents);
        }

        public void Delete(Agent agent)
        {
            var agents = All().ToList();
            agents.RemoveAll(a=>a.Identifier == agent.Identifier);
            WriteAll(agents);
        }

        private void WriteAll(List<Agent> agents)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {

                foreach (var a in agents)
                {
                    sw.WriteLine($"{a.FirstName}," +
                        $"{a.MiddleName}," +
                        $"{a.LastName}," +
                        $"{a.PicturUrl}," +
                        $"{a.BirthDate}," +
                        $"{a.Height}," +
                        $"{a.Identifier}," +
                        $"{a.Agency}," +
                        $"{a.ActivationDate},"+
                        $"{a.SecurityClearance}," +
                        $"{a.IsActive}");
                }

            }
        }
        
    }
}
