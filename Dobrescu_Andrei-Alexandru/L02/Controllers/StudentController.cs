using L02.Models;
using L02.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;


namespace L02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {

        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return StudentRepo.Studenti;
        }

        [HttpGet("{id}")]
        public Student Get(int id)
        {
            foreach (var i in StudentRepo.Studenti)
            {
                if (i.id == id)
                    return i;
            }
            return null;

        }
        [HttpPost]
        public IEnumerable<Student> Post([FromBody] Student student)
        {
            StudentRepo.Studenti.Add(student);
            return StudentRepo.Studenti.ToArray();
        }
        [HttpPut]
        public IEnumerable<Student> Put([FromBody] Update update)
        {
            foreach (var i in StudentRepo.Studenti)
            {
                if (i.id == update.id)
                {
                    switch (update.camp.ToLower())
                    {
                        case "id":
                            i.id = Convert.ToInt32(update.valoare);
                            break;
                        case "nume":
                            i.nume = update.valoare;
                            break;
                        case "facultate":
                            i.facultate = update.valoare;
                            break;
                        case "an":
                            i.an = Convert.ToInt32(update.valoare);
                            break;
                    }
                    break;
                }

            }
            return StudentRepo.Studenti.ToArray();
        }
        [HttpDelete("{id}")]
        public IEnumerable<Student> Delete(int id)
        {
            foreach (var i in StudentRepo.Studenti)
            {
                if (i.id == id)
                {
                    StudentRepo.Studenti.Remove(i);
                    break;
                }

            }
            return StudentRepo.Studenti.ToArray();
        }
    }
}