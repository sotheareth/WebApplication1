using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApplication1.Contract;
using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IOptions<MySettingsModel> mySettings;
        private readonly SchoolContext _schoolContext;
        private readonly ILogger<ValuesController> _logger;
        private readonly IDiscount _discountService = OrderDiscountService.GetInstance();

        public ValuesController(IOptions<MySettingsModel> appSettings, 
            ILogger<ValuesController> logger,
            SchoolContext schoolContext,
            IDiscount discountService)
        {
            mySettings = appSettings;
            this._logger = logger;
            this._schoolContext = schoolContext;
            //I think we can avoid bind in constructor by using singleton pattern for below line
            //this._discountService = discountService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {           

            //String dbName = mySettings.Value.DbConnection;

            ////add course
            //var course = new Course { 
            //    Credits = 1,
            //    Title = "test"
            //};
            //_schoolContext.Courses.Add(course);

            ////add student
            //Student student = new Student
            //{
            //    EnrollmentDate = DateTime.Now,
            //    FirstMidName = "Ham",
            //    LastName = "Sotheareth"                
            //};
            //_schoolContext.Students.Add(student);
            //_schoolContext.SaveChanges();

            //Enrollment enrollment = new Enrollment
            //{
            //    CourseID = course.CourseID,
            //    StudentID = student.ID,
                
            //};
            //_schoolContext.Enrollments.Add(enrollment);
            //_schoolContext.SaveChanges();

            _logger.LogInformation("XXXXXXXXXXXXX DONE");

            var request = new TransferRequest
            {
                payment_credit_date = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                payment_type = "payment-type-EU-SEPA-Step2",
                who_pays_charges = "shared",
                reference = "This is test",
                amount = 1,
                ledger_from_id = "5f20010f-b464-4ded-976d-7b8c0af0ba5d",
                beneficiary_id = "5f2004eb-de7d-41db-95a9-8319e1dcddcc"
            };
            Helper.Helper.Test<TransferRequest>(request);
            //var result = Helper.Helper.SendAsync<TransferRequest, TransferResponse>("https://playlive.railsbank.com/v1/customer/transactions", request);
            //var student = new Student { 
            //    EnrollmentDate = DateTime.Now,
            //    FirstMidName = "test",
            //    LastName = "test"
            //};
            //var result = Helper.Helper.SendAsync<Student, TransferResponse>("https://localhost:44338/api/values/RegisterStudent", student);
            //if (result != null)
            //{
            //    _logger.LogInformation("xxxxxxxxxxxxxxxxxx DONE");
            //}

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // GET api/values/5
        [HttpGet("pair/{id}")]
        public ActionResult<string> Get([FromQuery(Name = "pair")] List<String> pair, int id)
        {
            return string.Concat(id, " ", string.Join(",", pair));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // POST api/values
        [HttpPost("RegisterStudent")]
        public void RegisterStudent([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {

            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
