using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Media;


namespace XamCal2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        MediaPlayer player;
        MediaPlayer player2;
        // private TextView textMessage;
        private TextView txtNum1, txtNum2;
        private double Num1, Num2, Result;
        private Button btnPlus, btnMinus, btnMul, btndivide, btnsound, btnsound2;

        // this is like a constructor 
        protected override void OnCreate(Bundle savedInstanceState)
        {



            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);



            btnMinus = FindViewById<Button>(Resource.Id.btnminus);
            btnMul = FindViewById<Button>(Resource.Id.btnmul);
            btndivide = FindViewById<Button>(Resource.Id.btndivide);
            txtNum1 = FindViewById<TextView>(Resource.Id.txtNum1);
            txtNum2 = FindViewById<TextView>(Resource.Id.txtNum2);
            btnPlus = FindViewById<Button>(Resource.Id.btnplus);
            btnsound = FindViewById<Button>(Resource.Id.btnsound);
            btnsound2 = FindViewById<Button>(Resource.Id.btnsound2);

            btndivide.Click += Btndivide_Click;
            btnsound.Click += Btnsound_Click;
            btnsound2.Click += Btnsound2_Click;
            player = MediaPlayer.Create(this, Resource.Raw.PreyEx2);
            player2 = MediaPlayer.Create(this, Resource.Raw.a);



        }

        private void Btnsound2_Click(object sender, EventArgs e)
        {
            player2.Start();
        }

        private void Btnsound_Click(object sender, EventArgs e)
        {
            // Button FakeB = (Button)sender;
            //ButtonFake(FakeB.Text);

            player.Start();
        }

        public void ButtonFake(string buttonSw)
        {
            {
                switch (buttonSw)

                {
                    case "play":

                        player.Start();

                        break;



                }






            }






        }




        private void Btndivide_Click(object sender, System.EventArgs e)
        {
            Num1 = Convert.ToDouble(txtNum1.Text);
            Num2 = Convert.ToDouble(txtNum2.Text);
            Result = Num1 / Num2;
            string result = (Num1 + " / " + Num2 + " = " + Result);
            Toast.MakeText(this, "The Result is " + Result, ToastLength.Long).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}