using Dapper;
using System;
using System.Collections.Generic;
using Npgsql;
using System.Linq;

namespace CloudResumeChallengeBackend.Repository
{
    public class BaseRepository
    {
        public string ConnectionString { get; }
        public NpgsqlConnection Connection { get; }
        public BaseRepository(string cs) {

            ConnectionString = cs;
            using var connection = new NpgsqlConnection(ConnectionString);
        }


        public List<T> Query<T>(string query, object parameters = null)
        {
            try
            {


                return Connection.Query<T>(query, parameters).ToList<T>();
                
            }
            catch (Exception ex)
            {
                //Handle the exception
                return default;
            }
        }

        public T QueryFirst<T>(string query, object parameters = null)
        {
            try
            {


                return Connection.QueryFirst<T>(query, parameters);

            }
            catch (Exception ex)
            {
                //Handle the exception
                return default;
            }
        }


        public T QuerySingle<T>(string query, object parameters = null)
        {
            try
            {


                return Connection.QuerySingle<T>(query, parameters);

            }
            catch (Exception ex)
            {
                //Handle the exception
                return default;
            }
        }

        public T QuerySingleOrDefault<T>(string query, object parameters = null)
        {
            try
            {


                return Connection.QuerySingleOrDefault<T>(query, parameters);

            }
            catch (Exception ex)
            {
                //Handle the exception
                return default;
            }
        }


        public void Execute(string query, object parameters = null)
        {
            try
            {


                Connection.Execute(query, parameters);

            }
            catch (Exception ex)
            {
                //Handle the exception
                
            }
        }



    }
}
