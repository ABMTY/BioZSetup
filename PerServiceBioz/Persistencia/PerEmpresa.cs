﻿using EntServiceBioz.Entidad;
using IBM.Data.Informix;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerServiceBioz.Persistencia
{
    public class PerEmpresa : Persistencia
    {
        public List<EntEmpresa> ObtenerTodos()
        {
            List<EntEmpresa> Lista = new List<EntEmpresa>();
            EntEmpresa entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                var sql = "SELECT id_empresa, razon_social, direccion, estado, municipio,imagen FROM informix.empresa";
                IfxCommand cmd = new IfxCommand(sql, Conexion);                
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntEmpresa();
                        entidad.id_empresa = int.Parse(dr["id_empresa"].ToString());
                        entidad.razon_social = dr["razon_social"].ToString();
                        entidad.direccion = dr["direccion"].ToString();
                        entidad.estado = dr["estado"].ToString();
                        entidad.municipio = dr["municipio"].ToString();
                        if (dr["imagen"].ToString() != string.Empty)
                        {
                            entidad.imagen = "data:image/png;base64," + dr["imagen"].ToString();                            
                        }
                        Lista.Add(entidad);
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                CerrarConexion();
            }
            return Lista;

        }
        public EntEmpresa Obtener(int id)
        {            
            EntEmpresa entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                
                IfxCommand cmd = new IfxCommand(string.Empty, Conexion);
                cmd.CommandText = "SELECT id_empresa, razon_social, direccion, estado, municipio,imagen FROM empresa WHERE id_empresa=?";
                cmd.Parameters.Add(new IfxParameter()).Value = id;
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad = new EntEmpresa();
                        entidad.id_empresa = int.Parse(dr["id_empresa"].ToString());
                        entidad.razon_social = dr["razon_social"].ToString();
                        entidad.direccion = dr["direccion"].ToString();
                        entidad.estado = dr["estado"].ToString();
                        entidad.municipio = dr["municipio"].ToString();
                        if (dr["imagen"].ToString() != string.Empty)
                        {
                            entidad.imagen = "data:image/png;base64," + dr["imagen"].ToString();                            
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                CerrarConexion();
            }
            return entidad;

        }
        public bool Insert(EntEmpresa entidad)
        {
            bool respuesta = false;
            try
            {
                var sql = string.Empty;
                AbrirConexion();
                if (entidad.imagen!=null)
                    sql = "execute procedure dml_empresa (?,NULL,?,?,?,?,?);";
                else
                    sql = "execute procedure dml_empresa (?,NULL,?,?,?,?,NULL);";

                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "INSERT";                    
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.razon_social;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.direccion;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.estado;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.municipio;
                    if (entidad.imagen!=null)
                        cmd.Parameters.Add(new IfxParameter()).Value = entidad.imagen;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Empresa";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Empresa";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }
        public bool Update(EntEmpresa entidad)
        {
            bool respuesta = false;            
            try
            {
                var sql = string.Empty;
                AbrirConexion();
                if (entidad.imagen!=null)
                    sql = "execute procedure dml_empresa (?,?,?,?,?,?,?);";
                else
                    sql = "execute procedure dml_empresa (?,?,?,?,?,?,NULL);";

                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "UPDATE";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_empresa;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.razon_social;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.direccion;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.estado;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.municipio;
                    if (entidad.imagen!=null)
                        cmd.Parameters.Add(new IfxParameter()).Value = entidad.imagen;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }      

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Empresa";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Empresa";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }       
    }
 
}
