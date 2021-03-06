﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Net;
using Android.OS;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Mobile.com.Entidades.Fabricas;
using MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.ChecarConexao;

namespace MimAcher.Mobile.com.Activities
{
    [Activity(Label = "MimAcher", Theme = "@style/Theme.Splash")]
    public class MainActivity : FabricaTelasNormaisSemProcedimento
    {
        
        //Variaveis globais
        //até comunicar com o banco informações hipotéticas
        private readonly string _campus = "Serra";
        private readonly string _senha = null;
        private readonly string _nome = "Gustavo";
        private readonly string _email = null;
        private readonly string _nascimento = "09/10/1995";
        private readonly string _telefone = "00000000";
        private readonly string _localizacao = null;
        private string _emailInserido;
        private string _senhaInserida;

        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Exibindo o layout .axml
            SetContentView(Resource.Layout.Main);

            //chamando o serviço de conexao a internet, necessário fazer na activity
            var connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);

            //pra verificar o tempo de checagem de conexao com o servidor
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            ChecagemConexao.ChecarConexão(this, connectivityManager);
            stopwatch.Stop();
            var tempoIniciarMain = stopwatch.ToString();



            //Iniciando as variaveis do contexto
            var campoEmail = FindViewById<EditText>(Resource.Id.email);
            var campoSenha = FindViewById<EditText>(Resource.Id.senha);
            var entrar = FindViewById<Button>(Resource.Id.entrar);
            var inscrevase = FindViewById<Button>(Resource.Id.inscrevase);

            //Funcionalidades
            //Resgatando o que foi digitado nos EditText
            campoEmail.TextChanged += (sender, texto) => _emailInserido = texto.Text.ToString();
            campoSenha.TextChanged += (sender, texto) => _senhaInserida = texto.Text.ToString();

            stopwatch.Restart();
            entrar.Click += ButtonEntrarClick;
            stopwatch.Stop();
            var tempoLogar = stopwatch.ToString();

            //Tenho que fazer a autenticação no banco de dados
            //Ideia é buscar usuario no banco, se existir retorna true e checa senha, se nao retorna usuario inexistente
            //Busca senha neste mesmo usuario, se for igual retorna true se nao retorna senha invalida

            stopwatch.Restart();
            inscrevase.Click += ButtonInscreverClick;
            stopwatch.Stop();
            var tempoIniciarInscrever = stopwatch.ToString();
        }

        
        //função temporaria
        //deve pegar o usuario no banco
        private Dictionary<string, string> MontarUsuário()
        {
            var informacoes = new Dictionary<string, string>
            {
                ["campus"] = _campus,
                ["senha"] = _senha,
                ["email"] = _email,
                ["nome"] = _nome,
                ["telefone"] = _telefone,
                ["nascimento"] = _nascimento,
                ["localizacao"] = _localizacao
            };

            return informacoes;
        }

        private void ButtonInscreverClick(object sender, EventArgs e)
        {
            var progressDialog = ProgressDialog.Show(this, "Carregando", "Comunicando com o servidor...", true);
            progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);

            new Thread(new ThreadStart(delegate
            {
                Thread.Sleep(5000);//take 5 secs to do it's job

                RunOnUiThread(async () =>
                {
                    for (var i = 0; i < 100; i++)
                    {
                        await Task.Delay(50);
                    }

                    await InscreverClick();
                    progressDialog.Dismiss();
                });
            })).Start();
        }

        private async Task InscreverClick()
        {
            var myProgressBar = new ProgressBar(this)
            {
                Indeterminate = true,
                Visibility = ViewStates.Visible
            };
            await StartInscrever();
            myProgressBar.Visibility = ViewStates.Gone;
        }

        private async Task StartInscrever()
        {
            await Task.Run(() => {
                IniciarInscrever();
            });
            Thread.Sleep(3000);
        }

        private void ButtonEntrarClick(object sender, EventArgs e)
        {
            var progressDialog = ProgressDialog.Show(this, "Carregando", "Comunicando com o servidor...", true);
            progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);

            new Thread(new ThreadStart(delegate
            {
                Thread.Sleep(3000);//take 5 secs to do it's job

                RunOnUiThread(async () =>
                {
                    for (var i = 0; i < 100; i++)
                    {
                        await Task.Delay(50);
                    }

                    await EntrarClick();
                    progressDialog.Dismiss();
                });
            })).Start();
        }

        private async Task EntrarClick()
        {
            var myProgressBar = new ProgressBar(this)
            {
                Indeterminate = true,
                Visibility = ViewStates.Visible
            };
            await StartEntrar();
            myProgressBar.Visibility = ViewStates.Gone;
        }

        private async Task StartEntrar()
        {
            await Task.Run(() => {
                Usuario.Login(_emailInserido, _senhaInserida);
                var participante = new Participante(MontarUsuário());
                IniciarHome(this, participante);
                Finish();
            });
        }
    }
}

