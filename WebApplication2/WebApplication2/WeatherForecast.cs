// <copyright file="WeatherForecast.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

namespace WebApplication2
{
    /// <summary> This application defines a WeatherForecast class within the WebApplication2 namespace. </summary>
    public class WeatherForecast
    {
        /// <summary>Gets or sets the date.</summary>
        /// <value>The date.</value>
        public DateOnly Date { get; set; }

        /// <summary>Gets or sets the temperature c.</summary>
        /// <value>The temperature c.</value>
        public int TemperatureC { get; set; }

        /// <summary>Gets the temperature f.</summary>
        /// <value>The temperature f.</value>
        public int TemperatureF => 32 + (int)(this.TemperatureC / 0.5556);

        /// <summary>Gets or sets the summary.</summary>
        /// <value>The summary.</value>
        public string? Summary { get; set; }
    }
}
