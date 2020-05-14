using System;
using System.ComponentModel.DataAnnotations.Schema; //added here for Table()


namespace SensorMobCRUD.Models
{
    [Table("measurments")]
    public class Measurment
    {
        public int Id { get; set; }             //PK
        public int sensorId { get; set; }       //corresponding sensor id
        public int pm_1_0 { get; set; }         //pm_1_0
        public int pm_2_5 { get; set; }         //pm_2_5    -       PM2.5 is particulate matter 2.5 micrometers or less in diameter.
        public int pm_10 { get; set; }          //pm_10     -       PM10 is particulate matter 10 micrometers or less in diameter
        public double temp { get; set; }        //temperature (°C)
        public double hum { get; set; }         //humidity (%)
        public DateTime time { get; set; }      //time stamp of the measurment of format ("%Y-%m-%d %H:%M:%S")
    }
}
//By way of comparison, a human hair is about 100 micrometres, so roughly 40 fine particles (pm_2.5) could be placed on its width.