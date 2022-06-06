using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RR3Trim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string? connectionDB;

        List<Row> rows = new List<Row>();
        private void btnReadBDCreateXML_Click(object sender, EventArgs e)
        {
            connectionDB = ConfigurationManager.AppSettings["ConexionBD"];


            using SqlConnection con = new SqlConnection(connectionDB);
            con.Open();

            string qry = @"SELECT *
                           FROM [PRO].[dbo].[MATRICULA_UNIZAR_MARCOS_SANCHEZ]";

            SqlCommand cmd = new SqlCommand(qry, con);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Row row = new Row
                {
                    CURSO_ACADEMICO = (int)reader["CURSO_ACADEMICO"],
                    LOCALIDAD = (string)reader["LOCALIDAD"],
                    TIPO_CENTRO = (string)reader["TIPO_CENTRO"],
                    CENTRO = (string)reader["CENTRO"],
                    ESTUDIO = (string)reader["ESTUDIO"],
                    TIPO_ESTUDIO = (string)reader["TIPO_ESTUDIO"],
                    NOMBRE_CCAA_ALUMNO = (string)reader["NOMBRE_CCAA_ALUMNO"],
                    SEXO = (string)reader["SEXO"],
                    MOVILIDAD_SALIDA = (string)reader["MOVILIDAD_SALIDA"],
                    DEDICACION = (string)reader["DEDICACION"],
                    ALUMNOS_MATRICULADOS = (int)reader["ALUMNOS_MATRICULADOS"],
                    FECHA_ACTUALIZACION = (DateTime)reader["FECHA_ACTUALIZACION"],
                };
                rows.Add(row);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Row>), new XmlRootAttribute("Rows"));
            //XmlSerializer serializer = new XmlSerializer(typeof(List<Row>), new XmlConvert().ToString());

            using TextWriter writer = new StreamWriter(@"./Unizar.xml");
            serializer.Serialize(writer, rows);
            MessageBox.Show("XML Creado correctamente");
        }

        private void btnReadXML_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"./Unizar.xml";
                XDocument myDoc = XDocument.Load(path);
                myDoc.Save("UnizarBienFromado.xml");
                txtPrueba.Text = myDoc.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void btnInsertBDFromXML_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var doc = XDocument.Load(openFileDialog1.FileName);
                    txtPrueba.Text = "Se ha cargado el xml";

                    using SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConexionBD"]);
                    con.Open();
                    foreach (var row in doc.Root.Descendants("Row"))
                    {
                        try
                        {
                            string sql = @"INSERT INTO [dbo].[MATRICULA_UNIZAR_MARCOS_SANCHEZ]
                                   ([CURSO_ACADEMICO]
                                   ,[LOCALIDAD]
                                   ,[TIPO_CENTRO]
                                   ,[CENTRO]
                                   ,[ESTUDIO]
                                   ,[TIPO_ESTUDIO]
                                   ,[NOMBRE_CCAA_ALUMNO]
                                   ,[SEXO]
                                   ,[MOVILIDAD_SALIDA]
                                   ,[DEDICACION]
                                   ,[ALUMNOS_MATRICULADOS]
                                   ,[FECHA_ACTUALIZACION])
                             VALUES
                                   (@CURSO_ACADEMICO
                                   ,@LOCALIDAD
                                   ,@TIPO_CENTRO
                                   ,@CENTRO
                                   ,@ESTUDIO
                                   ,@TIPO_ESTUDIO
                                   ,@NOMBRE_CCAA_ALUMNO
                                   ,@SEXO
                                   ,@MOVILIDAD_SALIDA
                                   ,@DEDICACION
                                   ,@ALUMNOS_MATRICULADOS
                                   ,@FECHA_ACTUALIZACION)";

                            SqlCommand cmd = new SqlCommand(sql, con);
                            cmd.Parameters.AddWithValue("CURSO_ACADEMICO", int.Parse(row.Element("CURSO_ACADEMICO").Value));
                            cmd.Parameters.AddWithValue("LOCALIDAD", row.Element("LOCALIDAD").Value);
                            cmd.Parameters.AddWithValue("TIPO_CENTRO", row.Element("TIPO_CENTRO").Value);
                            cmd.Parameters.AddWithValue("CENTRO", row.Element("CENTRO").Value);
                            cmd.Parameters.AddWithValue("ESTUDIO", row.Element("ESTUDIO").Value);
                            cmd.Parameters.AddWithValue("TIPO_ESTUDIO", row.Element("TIPO_ESTUDIO").Value);
                            cmd.Parameters.AddWithValue("NOMBRE_CCAA_ALUMNO", row.Element("NOMBRE_CCAA_ALUMNO").Value);
                            cmd.Parameters.AddWithValue("SEXO", row.Element("SEXO").Value);
                            cmd.Parameters.AddWithValue("MOVILIDAD_SALIDA", row.Element("MOVILIDAD_SALIDA").Value);
                            cmd.Parameters.AddWithValue("DEDICACION", row.Element("DEDICACION").Value);
                            cmd.Parameters.AddWithValue("ALUMNOS_MATRICULADOS", int.Parse(row.Element("ALUMNOS_MATRICULADOS").Value));
                            cmd.Parameters.AddWithValue("FECHA_ACTUALIZACION", DateTime.ParseExact(row.Element("FECHA_ACTUALIZACION").Value, "dd/MM/yyyy", CultureInfo.CurrentCulture));


                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex1)
                        {
                            MessageBox.Show("Error guardando el elmento. " + ex1.Message + " . El resto de datos se guardarán"); ;
                        }
                    }
                    txtPrueba.AppendText("Datos volcados a la BBDD");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado: " + ex.Message); ;
                }
            }
        }
        private void btnLinq_Click(object sender, EventArgs e)
        {
            string qry = @"SELECT * FROM [dbo].[MATRICULA_UNIZAR_MARCOS_SANCHEZ]";
            // EjecutarQuery(qry);

            /*Ejercicio 1: Muestre el número total de alumnos matriculados.*/
            qry = @"SELECT SUM(ALUMNOS_MATRICULADOS) AS 'Total Alumnos Matriculados'
                    FROM dbo.MATRICULA_UNIZAR_MARCOS_SANCHEZ";
            // EjecutarQuery(qry);

            /*Ejercicio 2: Muestre el número de alumnos por sexo.*/
            qry = @" SELECT SEXO AS 'Sexo', SUM(ALUMNOS_MATRICULADOS) AS 'Total Alumnos Matriculados'
                        FROM dbo.MATRICULA_UNIZAR_MARCOS_SANCHEZ
                        GROUP BY SEXO";
            // EjecutarQuery(qry);

            /*Ejercicio 3: Muestre los 5 estudios de máster con mayor número de alumnos y el número de alumnos que lo cursan.*/
            qry = @"SELECT TOP(5) ESTUDIO AS 'Estudio', ALUMNOS_MATRICULADOS AS 'Alumnos Matriculados'
                    FROM dbo.MATRICULA_UNIZAR_MARCOS_SANCHEZ
                    WHERE TIPO_ESTUDIO = 'Máster'
                    ORDER BY ALUMNOS_MATRICULADOS DESC";
            // EjecutarQuery(qry);

            /*Ejercicio 4: Muestre los 5 centros con mayor porcentaje de alumnos mujeres en estudios de grado que lo cursan junto con el número de mujeres,
            hombres y porcentaje de mujeres que cursan estudios de grado en dichos centros.*/
            qry = @" SELECT TOP(5) M.CENTRO, M.Mujeres * 100.0 / (M.Mujeres + H.Hombres) AS Porcentaje, M.Mujeres, H.Hombres

                                  FROM(SELECT CENTRO, SUM(ALUMNOS_MATRICULADOS) Mujeres

                                  FROM[MATRICULA_UNIZAR_MARCOS_SANCHEZ]

                                  WHERE TIPO_ESTUDIO = 'Grado' AND SEXO = 'Mujeres'

                                  GROUP BY CENTRO) AS M
                              LEFT JOIN
                                  (SELECT CENTRO, SUM(ALUMNOS_MATRICULADOS) Hombres

                                  FROM[MATRICULA_UNIZAR_MARCOS_SANCHEZ]
                                  WHERE TIPO_ESTUDIO = 'Grado' AND SEXO = 'Hombres'

                                  GROUP BY CENTRO) AS H
                              ON M.CENTRO = H.CENTRO
                              ORDER BY Porcentaje DESC";
            // EjecutarQuery(qry);

            /*Ejercicio 5: Muestre los 5 estudios de grado o master que se pueden cursar en un mayor número de localidades junto con las localidades donde se pueden cursar.*/
            qry = @" SELECT DISTINCT ESTUDIO, LOCALIDAD
                        FROM[MATRICULA_UNIZAR_MARCOS_SANCHEZ]
                               WHERE ESTUDIO IN(
                                                 SELECT TOP(5) ESTUDIO

                                                 FROM[MATRICULA_UNIZAR_MARCOS_SANCHEZ]

                                                 WHERE TIPO_ESTUDIO = 'Grado' OR TIPO_ESTUDIO = 'Máster'

                                                 GROUP BY ESTUDIO

                                                 ORDER BY COUNT(DISTINCT LOCALIDAD) DESC
                        )";
            // EjecutarQuery(qry);

            /*Ejercicio 6: Muestra todos los alumnos matriculados que estudien en un Centro adscrito en Teruel*/
            qry = @"SELECT SUM(ALUMNOS_MATRICULADOS) AS 'Alumnos turolenses de centros adscritos'
                    FROM dbo.MATRICULA_UNIZAR_MARCOS_SANCHEZ
                    WHERE TIPO_CENTRO = 'Centro adscrito' AND LOCALIDAD = 'Teruel'";
            // EjecutarQuery(qry);

            /*Ejercicio 7: Muestra todos los alumnos que en DEDICACION hacen tiempo completo y junto a ello muestra los estudios*/
            qry = @"SELECT ALUMNOS_MATRICULADOS AS 'Alumnos', ESTUDIO AS 'Estudio'
                    FROM dbo.MATRICULA_UNIZAR_MARCOS_SANCHEZ
                    WHERE DEDICACION = 'Tiempo Completo'";
            // EjecutarQuery(qry);

            /*Ejercicio 8: Muestra los estudios, que más número de alumnos cursan en la comunidad de Aragón*/
            qry = @"SELECT ESTUDIO AS 'Estudio', NOMBRE_CCAA_ALUMNO AS 'CCAA', ALUMNOS_MATRICULADOS AS 'Nº Alumnos'
                    FROM dbo.MATRICULA_UNIZAR_MARCOS_SANCHEZ
                    WHERE NOMBRE_CCAA_ALUMNO = 'Aragón'
                    ORDER BY ALUMNOS_MATRICULADOS DESC";
            EjecutarQuery(qry);
        }

        private void EjecutarQuery(string qry)
        {
            connectionDB = ConfigurationManager.AppSettings["ConexionBD"];
            using SqlConnection con = new SqlConnection(connectionDB);
            con.Open();

            SqlCommand cmd = new SqlCommand(qry, con);

            SqlDataReader reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            dG.DataSource = null;
            dG.DataSource = table;
        }
    }
}
