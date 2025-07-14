using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat.Services;
using Chat.Data;
using Chat.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.SignalR.Client;

namespace Chat.Forms
{
    public partial class CrearGrupoForm : Form
    {
        private User _currentUser;
        private HubConnection _connection;

        public CrearGrupoForm(User currentUser, HubConnection connection)
        {
            InitializeComponent();
            UIUtils.RedondearBoton(btnCrear);
            _currentUser = currentUser;
            _connection = connection; // Asigna la conexión recibida

            using (var db = new AppDbContext())
            {
                var userService = new UserService(db);
                var usuarios = userService.GetAllUsers()
                    .Where(u => u.Username != _currentUser.Username)
                    .ToList();

                foreach (var usuario in usuarios)
                {
                    checkedListBoxUsuarios.Items.Add(usuario, false);
                }
            }
        }



        private async void btnCrear_Click(object sender, EventArgs e)
        {
            string nombreGrupo = txtNombreGrupo.Text.Trim();
            if (string.IsNullOrEmpty(nombreGrupo))
            {
                new ErrorForm("Ingrese un nombre para el grupo").ShowDialog();
                return;
            }

            var usuariosSeleccionados = checkedListBoxUsuarios.CheckedItems
                .OfType<User>()
                .ToList();

            if (usuariosSeleccionados.Count == 0)
            {
                new ErrorForm("Seleccione al menos un usuario").ShowDialog();
                return;
            }

            using (var db = new AppDbContext())
            {
                // Crear el grupo
                var grupo = new Group { Name = nombreGrupo };
                db.Groups.Add(grupo);
                db.SaveChanges();

                // Agregar al usuario creador como miembro
                db.UserGroups.Add(new UserGroup
                {
                    GroupId = grupo.Id,
                    UserId = _currentUser.Id
                });

                // Agregar los demás miembros seleccionados
                foreach (var usuario in usuariosSeleccionados)
                {
                    db.UserGroups.Add(new UserGroup
                    {
                        GroupId = grupo.Id,
                        UserId = usuario.Id
                    });
                }
                db.SaveChanges();

                // Después de guardar el grupo y los miembros
                var usernames = usuariosSeleccionados.Select(u => u.Username).ToList();
                usernames.Add(_currentUser.Username); // Asegúrate de incluir al creador

                await _connection.InvokeAsync("NotifyGroupCreated", grupo.Id, usernames);

            }


            new SuccessForm("Grupo Creado correctamente").ShowDialog();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
