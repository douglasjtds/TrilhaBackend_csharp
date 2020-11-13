﻿using System;
using System.Collections.Generic;
using System.Text;
using TrilhaBackendCSharp.Dominio.Entidades;

namespace TrilhaBackendCSharp.Dominio.Repositorios
{
    public interface IClienteRepositorio
    {
        List<Cliente> Consultar(string cpf = "");
        void Salvar(Cliente cliente);
        bool Remover(string cpf);
    }
}
