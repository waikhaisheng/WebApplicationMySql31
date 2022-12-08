using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Threading.Tasks;

namespace WebApplicationMySql31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MySqlConnection _mySqlConnection;
        public ValuesController(MySqlConnection mySqlConnection)
        {
            _mySqlConnection = mySqlConnection;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //using var _mySqlConnection = new MySqlConnection("server=localhost;user id=root;password=toor;port=3306;database=new_schema_test");

            await _mySqlConnection.OpenAsync();

            using var command = new MySqlCommand("SELECT id FROM new_schema_test.new_table_test;", _mySqlConnection);
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var value = reader.GetValue(0);
                // do something with 'value'
            }

            var task = Task.FromResult(Ok());

            var ret = await task;

            return ret;
        }
    }
}
