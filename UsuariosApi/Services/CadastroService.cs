﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;

        public UsuarioService(UserManager<Usuario> userManager, IMapper mapper, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public async Task CadastraUsuario(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario,
                dto.Password);

            if (!resultado.Succeeded) {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            } 

            
        }

        public async Task Login(LoginUsuarioDto dto)
        {
          var resultado= await _signInManager.PasswordSignInAsync
                (dto.Username, dto.Password, false, false);
            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuario não autenticado!");
            }
        }
    }
}
