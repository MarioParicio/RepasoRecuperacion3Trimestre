﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RR3Trim
{
    public class Row
    {
		[XmlElement]
		public int CURSO_ACADEMICO { get; set; }

		[XmlElement]
		public string LOCALIDAD { get; set; }

		[XmlElement]
		public string TIPO_CENTRO { get; set; }

		[XmlElement]
		public string CENTRO { get; set; }

		[XmlElement]
		public string ESTUDIO { get; set; }

		[XmlElement]
		public string TIPO_ESTUDIO { get; set; }
		[XmlElement]
		public string NOMBRE_CCAA_ALUMNO { get; set; }
		[XmlElement]
		public string SEXO { get; set; }
		[XmlElement]
		public string MOVILIDAD_SALIDA { get; set; }
		[XmlElement]
		public string DEDICACION { get; set; }
		[XmlElement]
		public int ALUMNOS_MATRICULADOS { get; set; }
		[XmlElement]
		public DateTime FECHA_ACTUALIZACION { get; set; }
	}
}
