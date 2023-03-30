using Consultorio.DataAccess.Repository;
using ConsultorioClinico.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.BussinesLogic.Services
{
    public class AcceService
    {
        private readonly RolesRepository _rolesRepository;
        private readonly UsuarioRepository _usuarioRepository;

        public AcceService(RolesRepository rolesRepository, UsuarioRepository usuarioRepository)
        {
            _rolesRepository = rolesRepository;
            _usuarioRepository = usuarioRepository;
        }

        #region Roles
        public ServiceResult ListaRoles()
        {
            var result = new ServiceResult();
            try
            {
                var list = _rolesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarRoles(VW_tbRoles item)
        {
            var result = new ServiceResult();

            try
            {
                var insert = _rolesRepository.Insert(item);

                if (insert.MessageStatus == "El registro se ha insertado con éxito")
                    return result.SetMessage(insert.MessageStatus, ServiceResultType.Success);
                else if (insert.MessageStatus == "Ya existe un rol con este nombre")
                    return result.Conflict(insert.MessageStatus);
                else
                    return result.SetMessage("Por favor llene todos los campos", ServiceResultType.Conflict);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EditarRoles(VW_tbRoles item, int id)
        {
            var result = new ServiceResult();
            try
            {
                var update = _rolesRepository.Update(item, id);
                if (update.MessageStatus == "El registro ha sido editado con éxito")
                    return result.SetMessage(update.MessageStatus, ServiceResultType.Success);
                else if (update.MessageStatus == "El registro que intenta editar no existe")
                    return result.Conflict(update.MessageStatus);
                else if (update.MessageStatus == "Ya existe un rol con este nombre")
                    return result.Conflict(update.MessageStatus);
                else
                    return result.SetMessage("Por favor llene todos los campos", ServiceResultType.Conflict);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarRoles(int id)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _rolesRepository.DeleteConfirmed(id);
                if (delete.MessageStatus == "El registro ha sido eliminado con éxito")
                    return result.SetMessage(delete.MessageStatus, ServiceResultType.Success);
                else if (delete.MessageStatus == "El registro que intenta eliminar no existe")
                    return result.Conflict(delete.MessageStatus);
                else
                    return result.SetMessage(delete.MessageStatus, ServiceResultType.Conflict);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Usuarios
        public ServiceResult ListaUsuarios()
        {
            var result = new ServiceResult();
            try
            {
                var list = _usuarioRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarUsuarios(VW_tbUsuarios_View item)
        {
            var result = new ServiceResult();

            try
            {
                var insert = _usuarioRepository.Insert(item);

                if (insert.MessageStatus == "El registro se ha insertado con éxito")
                    return result.SetMessage(insert.MessageStatus, ServiceResultType.Success);
                else if (insert.MessageStatus == "Ya existe un rol con este nombre")
                    return result.Conflict(insert.MessageStatus);
                else
                    return result.SetMessage("Por favor llene todos los campos", ServiceResultType.Conflict);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EditarUsuarios(VW_tbUsuarios_View item, int id)
        {
            var result = new ServiceResult();
            try
            {
                var update = _usuarioRepository.Update(item, id);
                if (update.MessageStatus == "El registro ha sido editado con éxito")
                    return result.SetMessage(update.MessageStatus, ServiceResultType.Success);
                else if (update.MessageStatus == "El registro que intenta editar no existe")
                    return result.Conflict(update.MessageStatus);
                else if (update.MessageStatus == "Ya existe un rol con este nombre")
                    return result.Conflict(update.MessageStatus);
                else
                    return result.SetMessage("Por favor llene todos los campos", ServiceResultType.Conflict);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarUsuarios(int id)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _usuarioRepository.DeleteConfirmed(id);
                if (delete.MessageStatus == "El registro ha sido eliminado con éxito")
                    return result.SetMessage(delete.MessageStatus, ServiceResultType.Success);
                else if (delete.MessageStatus == "El registro que intenta eliminar no existe")
                    return result.Conflict(delete.MessageStatus);
                else
                    return result.SetMessage(delete.MessageStatus, ServiceResultType.Conflict);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public IEnumerable<VW_tbUsuarios_View> Login(string user, string contrasena)
        {
            try
            {
                return _usuarioRepository.Login(user, contrasena);

            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}
