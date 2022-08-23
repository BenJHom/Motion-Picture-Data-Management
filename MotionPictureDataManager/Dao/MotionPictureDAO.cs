using MotionPictureDataManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MotionPictureDataManager.Dao
{
    public class MotionPictureDAO : IMotionPictureDAO
    {
        private readonly string connectionString;
        public MotionPictureDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<MotionPicture> GetAllMotionPictures()
        {
            List<MotionPicture> motionPictures = new List<MotionPicture>();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM MotionPictures",connection);
                command.CommandText = "SELECT * FROM MotionPictures";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    motionPictures.Add(ReaderToMotionPicture(reader));
                }
            }

            return motionPictures;
        }

        public MotionPicture AddMotionPicture(MotionPicture motionPicture)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO dbo.MotionPictures VALUES (@name, @description, @releaseYear); SELECT SCOPE_IDENTITY();", connection);
                command.Parameters.AddWithValue("@name", motionPicture.name);
                command.Parameters.AddWithValue("@description", motionPicture.description);
                command.Parameters.AddWithValue("@releaseYear", motionPicture.releaseYear);

                //Test ID of added obejct
                motionPicture.id = Convert.ToInt32(command.ExecuteScalar());
            }
            return motionPicture;
        }

        public Boolean UpdateMotionPicture(MotionPicture motionPicture)
        {
            Boolean successful = false;
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE MotionPictures SET name = @name, description = @description, release_year = @releaseYear WHERE id = @id", connection);
                command.Parameters.AddWithValue("@name", motionPicture.name);
                command.Parameters.AddWithValue("@description", motionPicture.description);
                command.Parameters.AddWithValue("@releaseYear", motionPicture.releaseYear);
                command.Parameters.AddWithValue("@id", motionPicture.id);
                command.ExecuteNonQuery();

                successful = true;
            }
            return successful;
        }

        public Boolean DeleteMotionPicture(int id)
        {
            Boolean successful = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM MotionPictures WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();

                successful = true;
            }

            return successful;
        }

        public MotionPicture ReaderToMotionPicture(SqlDataReader data)
        {
            MotionPicture motionPicture = new MotionPicture();

            motionPicture.id = Convert.ToInt32(data["id"]);
            motionPicture.name = Convert.ToString(data["name"]);
            motionPicture.description = Convert.ToString(data["description"]);
            motionPicture.releaseYear = Convert.ToInt32(data["release_year"]);

            return motionPicture;
        }

    }
}
