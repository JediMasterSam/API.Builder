using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Api.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using static System.Reflection.Assembly;

namespace Api
{
    /// <summary>
    /// This is the program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main method.
        /// </summary>
        /// <param name="args">What pirates say.</param>
        public static void Main(string[] args)
        {
            GetExecutingAssembly().Run<Startup>(args);
        }
    }

    /// <summary>
    /// This is a foo.
    /// </summary>
    public class Foo
    {
        /// <summary>
        /// Some bar.
        /// </summary>
        public Bar[] Bar { get; set; }

        /// <summary>
        /// The ID for getting more Foo.
        /// </summary>
        public int? Id { get; set; }
    }

    /// <summary>
    /// Not chocolate.
    /// </summary>
    public class Bar
    {
        /// <summary>
        /// The ID for getting more Bar.
        /// </summary>
        public int Id { get; set; } = 50;

        /// <summary>
        /// My name.
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// State information.
    /// </summary>
    public enum State
    {
        /// <summary>
        /// The state is on.
        /// </summary>
        On = 1,

        /// <summary>
        /// The state is off.
        /// </summary>
        Off = 2
    }

    /// <summary>
    /// Controller stuff.
    /// </summary>
    [ApiVersion("1.0")]
    public class FooController : ControllerBase
    {
        /// <summary>
        /// Hi there.
        /// </summary>
        /// <param name="foo">Foobar.</param>
        [HttpPost]
        [Ok(typeof(Foo))]
        public virtual IActionResult GetFoo([FromBody] Foo foo)
        {
            return Ok(foo);
        }

        /// <summary>
        /// Adds two numbers yo.
        /// </summary>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <returns></returns>
        [HttpGet]
        [Ok(typeof(int))]
        public IActionResult Add2([FromRoute] [Range(0, 5)] int a, [FromQuery] int b = 30)
        {
            return Ok(a + b);
        }

        /// <summary>
        /// Adds three numbers dawg.
        /// </summary>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <param name="c">C</param>
        /// <returns></returns>
        [HttpGet]
        [Ok(typeof(int))]
        public IActionResult Add3([FromRoute] int a, [FromRoute] int b, [FromRoute] int c)
        {
            return Ok(a + b + c);
        }

        /// <summary>
        /// Subtracts two numbers yall.
        /// </summary>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <returns></returns>
        [HttpPost]
        [Ok(typeof(int))]
        public IActionResult Subtract2([FromQuery] int a, [FromQuery] int b)
        {
            return Ok(a - b);
        }

        /// <summary>
        /// Flips the state.
        /// </summary>
        /// <param name="state">The current state.</param>
        [HttpGet]
        [Ok(typeof(State))]
        public IActionResult FlipState([FromRoute] State state)
        {
            return state switch
            {
                State.Off => Ok(State.On),
                State.On => Ok(State.Off),
                _ => throw new ArgumentOutOfRangeException(nameof(state))
            };
        }
    }

    /// <summary>
    /// Like Mewtwo.
    /// </summary>
    [ApiVersion("2.0")]
    [ControllerName("Foo")]
    public class Foo2Controller : FooController
    {
        /// <inheritdoc/>
        [HttpPost]
        [Ok(typeof(Foo))]
        [BadRequest(typeof(Foo))]
        public override IActionResult GetFoo([FromBody] Foo foo)
        {
            return base.GetFoo(foo);
        }

        /// <summary>
        /// This does not do anything.
        /// </summary>
        [HttpGet]
        [Ok(typeof(Foo))]
        public IActionResult GetAllFoo()
        {
            return Ok();
        }
    }
}