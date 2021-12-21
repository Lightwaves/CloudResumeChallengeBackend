using Dapper;
using System;
using System.Collections.Generic;
using Npgsql;
using System.Linq;
using NpgsqlTypes;
using System.Data;
using System.Net;

namespace CloudResumeChallengeBackend.Repository
{
    public class BaseRepository : IDisposable
    {
        public string ConnectionString { get; }
        public NpgsqlConnection Connection { get; }
        
        public BaseRepository(string cs) {

            ConnectionString = cs;
            Connection = new NpgsqlConnection(ConnectionString);
            var ipAddressHandler =
        new PassThroughHandler<IPAddress>(NpgsqlDbType.Inet);
            SqlMapper.AddTypeHandler(ipAddressHandler);
        }


        internal List<T> Query<T>(string query, object parameters = null)
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

        internal T QueryFirst<T>(string query, object parameters = null)
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


        internal T QuerySingle<T>(string query, object parameters = null)
        {
            try
            {


                return Connection.QuerySingle<T>(query, parameters);

            }
            catch (Exception ex)
            {
                //Handle the exception
                throw ex;
            }
        }

        internal T QuerySingleOrDefault<T>(string query, object parameters = null)
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


        internal void Execute(string query, object parameters = null)
        {
            try
            {


                Connection.Execute(query, parameters);
                

            }
            catch (Exception ex)
            {
                //Handle the exception
                throw ex;
                
            }
        }


        public void Dispose()
        {
            Connection.Dispose();
        }
    }

    internal class PassThroughHandler<T> : SqlMapper.TypeHandler<T>
    {

        #region Fields

        /// <summary>Npgsql database type being handled</summary>
        private readonly NpgsqlDbType _dbType;

        #endregion

        #region Constructors

        /// <summary>Constructor</summary>
        /// <param name="dbType">Npgsql database type being handled</param>
        public PassThroughHandler(NpgsqlDbType dbType)
        {
            _dbType = dbType;
        }

        #endregion

        #region Methods

        public override void SetValue(IDbDataParameter parameter, T value)
        {
            parameter.Value = value;
            parameter.DbType = DbType.Object;
            var npgsqlParam = parameter as NpgsqlParameter;
            if (npgsqlParam != null)
            {
                npgsqlParam.NpgsqlDbType = _dbType;
            }
        }

        public override T Parse(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return default(T);
            }
            if (!(value is T))
            {
                throw new ArgumentException(string.Format(
                    "Unable to convert {0} to {1}",
                    value.GetType().FullName, typeof(T).FullName), "value");
            }
            var result = (T)value;
            return result;
        }

        #endregion

    }
}



