using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int texTelhado;
        int texPorta;
        int texGrama;
        int texPisocasa;
        int texJanelaBanheiro;
        int texpisobancada;
        int texportao;
        int texConcreto;
        int texJanelaQuarto;
        int texJanelaCozinha;
        int texPortaSala;
        int lateral = 0;
        Vector3d dir = new Vector3d(0, -450, 120);        //direção da câmera
        Vector3d pos = new Vector3d(0, -550, 120);     //posição da câmera
        float camera_rotation = 0;                     //rotação no eixo Z


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); //limpa os buffers
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity(); //zera a matriz de projeção com a matriz identidade


            //                 Matrix4 lookat = Matrix4.LookAt(lateral, -500.0f, 1.5f,    
            //                                              1.5f, 5.0f, 1.5f,
            //                                           0.0f, 0.0f, 1.0f);
            Matrix4d lookat = Matrix4d.LookAt(pos.X, pos.Y, pos.Z, dir.X, dir.Y, dir.Z, 0, 0, 1);
            //aplica a transformacao na matriz de rotacao
            GL.LoadMatrix(ref lookat);
            //GL.Rotate(camera_rotation, 0, 0, 1);

            GL.Enable(EnableCap.DepthTest);

            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0); GL.Vertex3(500, 0, 0);
            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 500, 0);
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 0, 500);
            GL.End();

            //piso casa
            GL.Enable(EnableCap.Texture2D); //habilita o uso de texturas
            GL.BindTexture(TextureTarget.Texture2D, texPisocasa);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 5.0f); GL.Vertex3(0, 0, 0);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, 250, 0);
            GL.TexCoord2(8.0f, 0.0f); GL.Vertex3(700, 250, 0);
            GL.TexCoord2(8.0f, 5.0f); GL.Vertex3(700, 0, 0);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            GL.Enable(EnableCap.Texture2D); //habilita o uso de texturas
            GL.BindTexture(TextureTarget.Texture2D, texPisocasa);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 5.0f); GL.Vertex3(350, 0, 0);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(350, -700, 0);
            GL.TexCoord2(8.0f, 0.0f); GL.Vertex3(700, -700, 0);
            GL.TexCoord2(8.0f, 5.0f); GL.Vertex3(700, 0, 0);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //concreto
            GL.Enable(EnableCap.Texture2D); //habilita o uso de texturas
            GL.BindTexture(TextureTarget.Texture2D, texConcreto);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 5.0f); GL.Vertex3(0, 0, 0);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, -700, 0);
            GL.TexCoord2(8.0f, 0.0f); GL.Vertex3(350, -700, 0);
            GL.TexCoord2(8.0f, 5.0f); GL.Vertex3(350, 0, 0);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //LAJE Cozinha e Sala
            GL.Color3(Color.WhiteSmoke);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 5.0f); GL.Vertex3(0, 0, 200);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, 250, 200);
            GL.TexCoord2(8.0f, 0.0f); GL.Vertex3(600, 250, 200);
            GL.TexCoord2(8.0f, 5.0f); GL.Vertex3(600, 0, 200);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //LAJE banheiro e quarto
            GL.Color3(Color.WhiteSmoke);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 5.0f); GL.Vertex3(350, 0, 200);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(350, -600, 200);
            GL.TexCoord2(8.0f, 0.0f); GL.Vertex3(600, -600, 200);
            GL.TexCoord2(8.0f, 5.0f); GL.Vertex3(600, 0, 200);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //Marmore da Bancada 1
            GL.Color3(Color.SaddleBrown);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 5.0f); GL.Vertex3(375, 0, 75);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(375, 85, 75);
            GL.TexCoord2(8.0f, 0.0f); GL.Vertex3(325, 85, 75);
            GL.TexCoord2(8.0f, 5.0f); GL.Vertex3(325, 0, 75);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //Marmore da Bancada 2
            GL.Color3(Color.SaddleBrown);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 5.0f); GL.Vertex3(375, 75, 50);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(375, 150, 50);
            GL.TexCoord2(8.0f, 0.0f); GL.Vertex3(325, 150, 50);
            GL.TexCoord2(8.0f, 5.0f); GL.Vertex3(325, 75, 50);
            GL.End();
            GL.Disable(EnableCap.Texture2D);


            //PAREDE DA FRENTE
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(350, 0.0, 200);
            GL.Vertex3(350,0, 0.0);
            GL.Vertex3(250, 0.0, 0.0);
            GL.Vertex3(250, 0.0, 200);

            GL.Vertex3(100, 0.0, 60.0);
            GL.Vertex3(100, 0.0, 0.0);
            GL.Vertex3(250, 0.0, 0.0);
            GL.Vertex3(250, 0.0, 60.0);
            GL.Vertex3(100, 0.0, 200.0);
            GL.Vertex3(100, 0.0, 140.0);
            GL.Vertex3(250, 0.0, 140.0);
            GL.Vertex3(250, 0.0, 200.0);

            GL.Vertex3(0.0, 0.0, 0.0);
            GL.Vertex3(0.0, 0.0, 200);
            GL.Vertex3(100.0, 0.0, 200.0);
            GL.Vertex3(100.0, 0.0, 0.0);

            GL.End();


            //JANELA  cozinha
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texJanelaCozinha);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(232f / 512f, 15f / 512f); GL.Vertex3(100, 0, 140);
            GL.TexCoord2(505f / 512f, 15f / 512f); GL.Vertex3(250, 0, 140);
            GL.TexCoord2(505f / 512f, 175f / 512f); GL.Vertex3(250, 0, 60);
            GL.TexCoord2(232f / 512f, 175f / 512f); GL.Vertex3(100, 0, 60);
            GL.End();

            //JANELA quarto
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texJanelaQuarto);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(232f / 512f, 15f / 512f); GL.Vertex3(350, -370, 60);//a
            GL.TexCoord2(505f / 512f, 15f / 512f); GL.Vertex3(350, -520, 60);//b
            GL.TexCoord2(505f / 512f, 175f / 512f); GL.Vertex3(350, -520, 140);//d
            GL.TexCoord2(232f / 512f, 175f / 512f); GL.Vertex3(350, -370, 140);//c
            GL.End();

           //piso + bancada
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texpisobancada); //utiliza a textura1

            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f / 210f, 0f / 210f);
            GL.Vertex3(350, 0, 0);
            GL.TexCoord2(210f / 210f, 0f / 210f);
            GL.Vertex3(350, 75, 0);
            GL.TexCoord2(210f / 210f, 210f / 210f);
            GL.Vertex3(350, 75, 75);
            GL.TexCoord2(0f / 210f, 210f / 210f);
            GL.Vertex3(350, 0, 75);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //piso + bancada2 
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texpisobancada); //utiliza a textura1

            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f / 210f, 0f / 210f);
            GL.Vertex3(350, 75, 0);
            GL.TexCoord2(210f / 210f, 0f / 210f);
            GL.Vertex3(350, 150, 0);
            GL.TexCoord2(210f / 210f, 210f / 210f);
            GL.Vertex3(350, 150, 50);
            GL.TexCoord2(0f / 210f, 210f / 210f);
            GL.Vertex3(350, 75, 50);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //JANELA banheiro
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texJanelaBanheiro);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(8f / 300f, 6f / 300f); GL.Vertex3(350, -190, 100);
            GL.TexCoord2(290f / 300f, 6f / 300f); GL.Vertex3(350, -260, 100);
            GL.TexCoord2(291f / 300f, 290f / 300f); GL.Vertex3(350, -260, 170);
            GL.TexCoord2(10f / 300f, 289f / 300f); GL.Vertex3(350, -190, 170);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //PAREDE LATERAL ESQUERDA cozinha
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 250, 0);
            GL.Vertex3(0, 250, 300);
            GL.Vertex3(0, 125, 250);
            GL.Vertex3(0, 0, 200);
            GL.End();

           //PORTA SALA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPortaSala); //utiliza a textura1

            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(162f / 512f, 499f / 512f);
            GL.Vertex3(350, -120, 0);
            GL.TexCoord2(42f / 512f, 499f / 512f);
            GL.Vertex3(350, -10, 0);
            GL.TexCoord2(42f / 512f, 195f / 512f);
            GL.Vertex3(350, -10, 170);
            GL.TexCoord2(162f / 512f, 195f / 512f);
            GL.Vertex3(350, -120, 170);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //PORTA BANHEIRO
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta); //utiliza a textura1

            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(162f / 512f, 499f / 512f);
            GL.Vertex3(500, -280, 0);
            GL.TexCoord2(42f / 512f, 499f / 512f);
            GL.Vertex3(500, -180, 0);
            GL.TexCoord2(42f / 512f, 195f / 512f);
            GL.Vertex3(500, -180, 180);
            GL.TexCoord2(162f / 512f, 195f / 512f);
            GL.Vertex3(500, -280, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //PORTA QUARTO
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texPorta); //utiliza a textura1

            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(162f / 512f, 499f / 512f);
            GL.Vertex3(505, -300, 0);
            GL.TexCoord2(42f / 512f, 499f / 512f);
            GL.Vertex3(595, -300, 0);
            GL.TexCoord2(42f / 512f, 195f / 512f);
            GL.Vertex3(595, -300, 180);
            GL.TexCoord2(162f / 512f, 195f / 512f);
            GL.Vertex3(505, -300, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //PAREDE LATERAL ESQUERDA
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(350, -600, 0);
            GL.Vertex3(350, -520, 0);
            GL.Vertex3(350, -520, 310);
            GL.Vertex3(350, -520, 310);
            GL.Vertex3(350, -600, 310);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(350, -10, 0);
            GL.Vertex3(350, 0, 0);
            GL.Vertex3(350, 0, 310);
            GL.Vertex3(350, 0, 310);
            GL.Vertex3(350, -10, 310);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(350, -260, 170);
            GL.Vertex3(350, -10, 170);
            GL.Vertex3(350, 0, 310);
            GL.Vertex3(350, -10, 310);
            GL.Vertex3(350, -260, 310);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(350, -120, 0);
            GL.Vertex3(350, -190, 0);
            GL.Vertex3(350, -190, 170);
            GL.Vertex3(350, -120, 170);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(350, -190, 0);
            GL.Vertex3(350, -260, 0);
            GL.Vertex3(350, -260, 100);
            GL.Vertex3(350, -190, 100);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(350, -370, 0);
            GL.Vertex3(350, -260, 0);
            GL.Vertex3(350, -260, 310);
            GL.Vertex3(350, -260, 310);
            GL.Vertex3(350, -370, 310);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(350, -520, 0);
            GL.Vertex3(350, -370, 0);
            GL.Vertex3(350, -370, 60);
            GL.Vertex3(350, -370, 60);
            GL.Vertex3(350, -520, 60);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(350, -520, 140);
            GL.Vertex3(350, -370, 140);
            GL.Vertex3(350, -370, 310);
            GL.Vertex3(350, -370, 310);
            GL.Vertex3(350, -520, 310);
            GL.End();

            //PAREDE LATERAL DIREITA
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(600, -600, 0);
            GL.Vertex3(600, 250, 0);
            GL.Vertex3(600, 250, 370);
            GL.Vertex3(600, 125, 370);
            GL.Vertex3(600, -600, 370);
            GL.End();

            //PAREDE frente banheiro
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(500, -300, 0);
            GL.Vertex3(500, -280, 0);
            GL.Vertex3(500, -280, 350);
            GL.Vertex3(500, -280, 350);
            GL.Vertex3(500, -300, 350);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(500, -180, 0);
            GL.Vertex3(500, -150, 0);
            GL.Vertex3(500, -150, 350);
            GL.Vertex3(500, -150, 350);
            GL.Vertex3(500, -180, 350);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(500, -280, 180);
            GL.Vertex3(500, -150, 180);
            GL.Vertex3(500, -150, 350);
            GL.Vertex3(500, -150, 350);
            GL.Vertex3(500, -280, 350);
            GL.End();

            //PAREDE Muro DIREITA
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(700, -700, 0);
            GL.Vertex3(700, 250, 0);
            GL.Vertex3(700, 250, 280);
            GL.Vertex3(700, 125, 280);
            GL.Vertex3(700, -700, 280);
            GL.End();

            //PAREDE Muro esquerda
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(-1, -700, 0);
            GL.Vertex3(-1, 250, 0);
            GL.Vertex3(-1, 250, 180);
            GL.Vertex3(-1, 125, 180);
            GL.Vertex3(-1, -700, 180);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(-1, -700, 180);
            GL.Vertex3(-1, -600, 180);
            GL.Vertex3(-1, -600, 180);
            GL.Vertex3(-1, -700, 200);
            GL.End();

            //PAREDE frente com portao
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads); //escolhe o tipo da primitiva
            GL.Vertex3(700, -700, 280); //A      //define as primitivas
            GL.Vertex3(700, -700, 0.0); //B     
            GL.Vertex3(350, -700, 0.0); //C
            GL.Vertex3(350, -700, 200); //D
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads); //escolhe o tipo da primitiva
            GL.Vertex3(350, -700, 200); //A      //define as primitivas
            GL.Vertex3(350, -700, 180); //B     
            GL.Vertex3(0, -700, 180); //C
            GL.Vertex3(0, -700, 200); //D
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads); //escolhe o tipo da primitiva
            GL.Vertex3(20, -700, 200); //A      //define as primitivas
            GL.Vertex3(20, -700, 0.0); //B     
            GL.Vertex3(0, -700, 0.0); //C
            GL.Vertex3(0, -700, 200); //D
            GL.End();

            //PORTão
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texportao); //utiliza a textura1

            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f / 300f, 0f / 200f);
            GL.Vertex3(350, -700, 180);
            GL.TexCoord2(300f / 300f, 0f / 200f);
            GL.Vertex3(350, -700, 0);
            GL.TexCoord2(300f / 300f, 200f / 200f);
            GL.Vertex3(20, -700, 0);
            GL.TexCoord2(0f / 300f, 200f / 200f);
            GL.Vertex3(20, -700, 180);
            GL.End();
            GL.Disable(EnableCap.Texture2D);


            //PAREDE viga
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Polygon); //escolhe o tipo da primitiva
            GL.Vertex3(350, 250, 150);
            GL.Vertex3(350, 0, 150);
            GL.Vertex3(350, 0, 310);
            GL.Vertex3(350, 0, 310);
            GL.Vertex3(350, 250, 310);
            GL.End();

            //PAREDE DE TRAS sala
            GL.Color3(Color.WhiteSmoke);
            GL.Begin(PrimitiveType.Quads); //escolhe o tipo da primitiva
            GL.Vertex3(600,250.0, 370); //A      //define as primitivas
            GL.Vertex3(600, 250.0, 0.0); //B     
            GL.Vertex3(0.0, 250.0, 0.0); //C
            GL.Vertex3(0.0, 250.0, 200); //D
            GL.End();

            GL.Color3(Color.WhiteSmoke);
            GL.Begin(PrimitiveType.Quads); //escolhe o tipo da primitiva
            GL.Vertex3(700, 250.0, 280); //A      //define as primitivas
            GL.Vertex3(700, 250.0, 0.0); //B     
            GL.Vertex3(600, 250.0, 0.0); //C
            GL.Vertex3(600, 250.0, 280); //D
            GL.End();

            //PAREDE DE TRAS cozinha
            GL.Color3(Color.WhiteSmoke);
            GL.Begin(PrimitiveType.Quads); //escolhe o tipo da primitiva
            GL.Vertex3(350, 250.0, 300); //A      //define as primitivas
            GL.Vertex3(350, 250.0, 0.0); //B     
            GL.Vertex3(0.0, 250.0, 0.0); //C
            GL.Vertex3(0.0, 250.0, 300); //D
            GL.End();

            //PAREDE do banheiro
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads); //escolhe o tipo da primitiva
            GL.Vertex3(500, -150, 340); //A      //define as primitivas
            GL.Vertex3(500, -150, 0.0); //B     
            GL.Vertex3(350, -150, 0.0); //C
            GL.Vertex3(350, -150, 300); //D
            GL.End();

            //PAREDE do banheiro
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads); //escolhe o tipo da primitiva
            GL.Vertex3(505, -300, 340); //A      //define as primitivas
            GL.Vertex3(505, -300, 0.0); //B     
            GL.Vertex3(350, -300, 0.0); //C
            GL.Vertex3(350, -300, 300); //D
            GL.End();

            //PAREDE QUARTO
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads); //escolhe o tipo da primitiva
            GL.Vertex3(500, -300, 340); //A      //define as primitivas
            GL.Vertex3(500, -300, 180); //B     
            GL.Vertex3(600, -300, 180); //C
            GL.Vertex3(600, -300, 300); //D
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads); //escolhe o tipo da primitiva
            GL.Vertex3(595, -300, 340); //A      //define as primitivas
            GL.Vertex3(595, -300, 0); //B     
            GL.Vertex3(600, -300, 0); //C
            GL.Vertex3(600, -300, 300); //D
            GL.End();

            //PAREDE frente quarto
            GL.Color3(Color.WhiteSmoke);
            GL.Begin(PrimitiveType.Quads); //escolhe o tipo da primitiva
            GL.Vertex3(600, -600, 375); //A      //define as primitivas
            GL.Vertex3(600, -600, 0.0); //B     
            GL.Vertex3(350, -600, 0.0); //C
            GL.Vertex3(350, -600, 310); //D
            GL.End();

            //TELHADO DIREITA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texTelhado);
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 3.0f);
            GL.Vertex3(-40, -40, 184);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(-40, 125, 250);
            GL.TexCoord2(2.0f, 0.0f);
            GL.Vertex3(350, 125, 250);
            GL.TexCoord2(2.0f, 3.0f);
            GL.Vertex3(350, -40, 184);
            GL.End();

            //continuação telhado
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0.0f, 3.0f);
            GL.Vertex3(-40, 290, 320);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(-40, 125, 250);
            GL.TexCoord2(2.0f, 0.0f);
            GL.Vertex3(350, 125, 250);
            GL.TexCoord2(2.0f, 3.0f);
            GL.Vertex3(350, 290, 320);
            GL.End();
            GL.Disable(EnableCap.Texture2D);

            //TELHADO lateral
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texTelhado);
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(3.0f, 0.0f);
            GL.Vertex3(230, -650, 280);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(230, 250, 280);
            GL.TexCoord2(0.0f, 2.0f);
            GL.Vertex3(700, 250, 400);
            GL.TexCoord2(3.0f, 2.0f);
            GL.Vertex3(700, -650, 400);
            GL.End();

            //TELHADO lavanderia
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texTelhado);
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(3.0f, 0.0f);
            GL.Vertex3(330, -700, 195);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex3(330, -600, 195);
            GL.TexCoord2(0.0f, 2.0f);
            GL.Vertex3(700, -600, 280);
            GL.TexCoord2(3.0f, 2.0f);
            GL.Vertex3(700, -700, 280);
            GL.End();

            /*//BEIRAL
             GL.Color3(Color.SaddleBrown);
             GL.Begin(PrimitiveType.Quads);
             GL.Vertex3(-40, -40, 174);
             GL.Vertex3(-40, 125, 240);
             GL.Vertex3(-40, 125, 250);
             GL.Vertex3(-40, -40, 184);

             GL.Vertex3(-40, 290, 174);
             GL.Vertex3(-40, 290, 184);
             GL.Vertex3(-40, 125, 250);
             GL.Vertex3(-40, 125, 240);

             GL.Vertex3(390, -40, 174);
             GL.Vertex3(390, 125, 240);
             GL.Vertex3(390, 125, 250);
             GL.Vertex3(390, -40, 184);

             GL.Vertex3(390, 290, 174);
             GL.Vertex3(390, 290, 184);
             GL.Vertex3(390, 125, 250);
             GL.Vertex3(390, 125, 240);

             GL.Vertex3(390, -40, 174);
             GL.Vertex3(390, -40, 184);
             GL.Vertex3(-40, -40, 184);
             GL.Vertex3(-40, -40, 174);

             GL.Vertex3(390, 290, 174);
             GL.Vertex3(390, 290, 184);
             GL.Vertex3(-40, 290, 184);
             GL.Vertex3(-40, 290, 174);

             GL.End();*/

            //EXEMPLO DE OBJETO TRANSPARENTE
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Enable(EnableCap.Blend);
            GL.Color4(0.1f, 0.5f, 0.6f, 0.6f); //Último parâmetro é a porcentagem de trasparência
           
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(-80, 50, 0);
            GL.Vertex3(-80, 100, 0);
            GL.Vertex3(-80, 100, 50);
            GL.Vertex3(-80, 50, 50);
            GL.End();
            GL.Disable(EnableCap.Blend);

            glControl1.SwapBuffers(); //troca os buffers de frente e de fundo 

        }
        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.Black);         // definindo a cor de limpeza do fundo da tela
            GL.Enable(EnableCap.Light0);

            texTelhado = LoadTexture("../../textura/telhado.jpg");
            texPorta = LoadTexture("../../textura/portajanela.jpg");
            texGrama = LoadTexture("../../textura/grama.jpg");
            texJanelaBanheiro = LoadTexture("../../textura/janelabanheiro.jpg");
            texpisobancada = LoadTexture("../../textura/pisobalcao.jpg");
            texportao = LoadTexture("../../textura/portao.jpg");
            texPisocasa = LoadTexture("../../textura/pisocasa.jpg");
            texConcreto = LoadTexture("../../textura/concreto.jpg");
            texJanelaQuarto = LoadTexture("../../textura/portajanela2.jpg");
            texPortaSala = LoadTexture("../../textura/portajanela2.jpg");
            texJanelaCozinha = LoadTexture("../../textura/portajanela3.jpg");

            SetupViewport();                      //configura a janela de pintura
        }

        private void SetupViewport() //configura a janela de projeção 
        {
            int w = glControl1.Width; //largura da janela
            int h = glControl1.Height; //altura da janela

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(1f, w / (float)h, 0.1f, 2000.0f);
            GL.LoadIdentity(); //zera a matriz de projeção com a matriz identidade

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            GL.Viewport(0, 0, w, h); // usa toda area de pintura da glcontrol
            lateral = w / 2;

        }

        static int LoadTexture(string filename)
        {
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException(filename);

            int id;//= GL.GenTexture(); 

            GL.GenTextures(1, out id);
            GL.BindTexture(TextureTarget.Texture2D, id);

            Bitmap bmp = new Bitmap(filename);

            BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bmp.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            return id;
        }
        private void calcula_direcao()
        {
            dir.X = pos.X + (Math.Sin(camera_rotation * Math.PI / 180) * 1000);
            dir.Y = pos.Y + (Math.Cos(camera_rotation * Math.PI / 180) * 1000);
        }
        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > lateral)
            {
                camera_rotation += 2;
            }
            if (e.X < lateral)
            {
                camera_rotation -= 2;
            }
            lateral = e.X;
            calcula_direcao();
            glControl1.Invalidate();
        }

        private void glControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            float a = camera_rotation;
            int tipoTecla = 0;
            if (e.KeyCode == Keys.Left)
            {
                a -= 90;
                tipoTecla = 1;
            }
            if (e.KeyCode == Keys.Right)
            {
                a += 90;
                tipoTecla = 1;
            }
            if (e.KeyCode == Keys.Up)
            { tipoTecla = 1; }
            if (e.KeyCode == Keys.Down)
            {
                a += 180;
                tipoTecla = 1;
            }

            if (e.KeyCode == Keys.D)
            {
                a += 1;
                tipoTecla = 2;
            }
            if (e.KeyCode == Keys.A)
            {
                a -= 1;
                tipoTecla = 2;
            }
            if (tipoTecla == 1)
            {
                if (a < 0) a += 360;
                if (a > 360) a -= 360;
                label2.Text = a.ToString();
                pos.X += (Math.Sin(a * Math.PI / 180) * 10);
                pos.Y += (Math.Cos(a * Math.PI / 180) * 10);
                calcula_direcao();
                glControl1.Invalidate(); 
            }

            if (tipoTecla == 2)
            {
                camera_rotation = a;
                calcula_direcao();
                glControl1.Invalidate();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            glControl1.Width = Form1.ActiveForm.Width - 10;
            glControl1.Height = Form1.ActiveForm.Height - 10;
            SetupViewport();
            glControl1.Invalidate();
        }

    }
}
