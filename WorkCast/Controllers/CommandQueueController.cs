using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WorkCast.Models;
using Microsoft.AspNetCore.Cors;

namespace WorkCast.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CommandQueueController : ControllerBase
    {
        private readonly Entities.WorkcastDbContext db = null;

        public CommandQueueController(Entities.WorkcastDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<Entities.Command[]> Queue()
        {
            return db.Commands.Where(c => !c.Complete).OrderBy(c => c.Id).ToArray();
        }

        [HttpGet]
        public ActionResult<Command> Dequeue()
        {
            Entities.Command command = db.Commands.Where(c => !c.Complete).OrderBy(c => c.Id).FirstOrDefault();

            if (command == null)
            {
                return BadRequest("No Commands found!");
            }

            command.DequeueTime = DateTime.Now;
            command.Complete = true;
            db.SaveChanges();

            Command result;

            try
            {
                switch (command.Code)
                {
                    case "X001": result = new X001(command); break;
                    case "X002": result = new X002(command); break;
                    case "X003": result = new X003(command); break;
                    case "X004": result = new X004(command); break;
                    case "X005": result = new X005(command); break;
                    case "X006": result = new X006(command); break;
                    case "X007": result = new X007(command); break;
                    case "X008": result = new X008(command); break;
                    case "X009": result = new X009(command); break;
                    case "X010": result = new X010(command); break;
                    case "X011": result = new X011(command); break;
                    case "X012": result = new X012(command); break;
                    default: result = new UnknownCommand(command); break;
                };
            }
            catch (Exception e)
            {
                result = new UnknownCommand(command);
                Console.WriteLine(e);
            }


            return result;
        }

        [HttpPost]
        public ActionResult<Entities.Command> Enqueue([FromQuery] string comm)
        {
            Entities.Command command = new Entities.Command
            {
                Code = comm.Substring(0, 4),
                CommandString = comm,
                EnqueueTime = DateTime.Now
            };

            db.Add(command);
            db.SaveChanges();

            return command;
        }

        [HttpGet]
        public ActionResult<Entities.Command[]> Seed()
        {
            string[] SeedData = {
                "X001ID=1234",
                "X002ID=1234|V=T|Q1=123|Q2=456|Q3=789",
                "X003=http://www.workcast.co.uk/",
                "X004=55656636633",
                "X005=”Sorry, these is a problem with the event. Please refresh your browser”",
                "X006=12345",
                "X007MEDI1=http://www.workcast.net/media/1234.mp4|MEDI2=http://www.workcast.net/media/4567.mp4",
                "X008=http://www.workcast.net/images/123.jpg",
                "X009=12345",
                "X010=”Thanks Tom. I have a question on the 3rd point you made?”",
                "X011ON=677722341234|OFF=7384384734573845|ON=563647893904308478",
                "X012=http://www.workcast.net",
                "X487=something_random"
            };

            List<Entities.Command> commands = new List<Entities.Command>();

            foreach (string seed in SeedData)
            {
                Entities.Command command = new Entities.Command
                {
                    Code = seed.Substring(0, 4),
                    CommandString = seed,
                };

                db.Add(command);
                commands.Add(command);
            }

            db.SaveChanges();

            return commands.ToArray();
        }
    }
}
