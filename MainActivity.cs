using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Media;
using Android.Util;
using Javax.Security.Auth;
using XamCal2.Resources.layout;


namespace XamCal2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        MediaPlayer player;
        MediaPlayer player2;
        //make a new list to hold the answers
        private List<string> AnswerList = new List<string>();
        //make a listview to tie into the one on the View
        private ListView lvAnswer;
        //Make an adapter to tie the List to the Listview.
        private ArrayAdapter<string> AnswerAdapter;
        // private TextView textMessage;
        private TextView txtNum1, txtNum2;
        private double Num1, Num2;
        private Button btnPlus, btnMinus, btnMul, btndivide, btnsound, btnsound2;
        private Button btnLoadBMI;

        private string Result = "";
        // this is like a constructor 
        protected override void OnCreate(Bundle savedInstanceState)
        {



            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            lvAnswer = FindViewById<ListView>(Resource.Id.lvAnswer);



            btnMinus = FindViewById<Button>(Resource.Id.btnminus);
            btnMul = FindViewById<Button>(Resource.Id.btnmul);
            btndivide = FindViewById<Button>(Resource.Id.btndivide);
            txtNum1 = FindViewById<TextView>(Resource.Id.txtNum1);
            txtNum2 = FindViewById<TextView>(Resource.Id.txtNum2);
            btnPlus = FindViewById<Button>(Resource.Id.btnplus);
            btnsound = FindViewById<Button>(Resource.Id.btnsound);
            btnsound2 = FindViewById<Button>(Resource.Id.btnsound2);

            btnLoadBMI = FindViewById<Button>(Resource.Id.btnLoadBMI);

            btnLoadBMI.Click += BtnLoadBMI_Click;
            btnPlus.Click += BtnMinus_Click;
            btnMinus.Click += BtnMinus_Click;
            btnMul.Click += BtnMinus_Click;
            btndivide.Click += BtnMinus_Click;
            btnsound.Click += Btnsound_Click;
            btnsound2.Click += Btnsound_Click;
            player = MediaPlayer.Create(this, Resource.Raw.PreyEx2);
            player2 = MediaPlayer.Create(this, Resource.Raw.a);

            ListViewAnswerUpdate();

        }

        private void BtnLoadBMI_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(BMI));
        }

        private void ListViewAnswerUpdate()
        {
            //https://www.youtube.com/watch?v=zZHLHrkvUt0 creating a listview
            //need an arrayadapter for the listview to tie it to the list of answerlist
            AnswerAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, AnswerList);
            //tie the adapter to the listview
            lvAnswer.Adapter = AnswerAdapter;
            //Add the answer to the adapter NOT the list!!!
            AnswerAdapter.Add("Test");
            //create a click event for the listview (not used yet)
            //lvAnswer.ItemClick += OnListItemClick;
        }
        private void BtnMinus_Click(object sender, EventArgs e)
        {
            Num1 = Convert.ToDouble(txtNum1.Text);
            Num2 = Convert.ToDouble(txtNum2.Text);
            Button fakebtn = (Button)sender;
            Btnfake(fakebtn.Text);
        }

        private void Btnfake(string FakSwitch)
        {

            switch (FakSwitch)
            {
                case "/":
                    Result = (Num1 / Num2).ToString();

                    break;

                case "X":
                    Result = (Num1 * Num2).ToString();
                    break;

                case "-":
                    Result = (Num1 - Num2).ToString();
                    break;

                case "+":
                    Result = (Num1 + Num2).ToString();
                    break;



            }
            AnswerAdapter.Add(Result);
            Toast.MakeText(this, "The Result is " + Result, ToastLength.Long).Show();
            string tag = "Log";
            Log.Info(tag, Num1.ToString());
            Log.Info(tag, Num2.ToString());
            Log.Info(tag, Result);

        }

        private void Btnsound2_Click(object sender, EventArgs e)
        {

        }

        private void Btnsound_Click(object sender, EventArgs e)
        {
            Button FakeB = (Button)sender;
            ButtonFake(FakeB.Text);


        }

        public void ButtonFake(string buttonSw)
        {
            {
                switch (buttonSw)

                {
                    case "play":

                        player.Start();
                        break;

                    case "play2":
                        player2.Start();
                        break;

                }






            }





        }




        private void Btndivide_Click(object sender, System.EventArgs e)
        {
            Num1 = Convert.ToDouble(txtNum1.Text);
            Num2 = Convert.ToDouble(txtNum2.Text);
            //  Result = Num1 / Num2;
            string result = (Num1 + " / " + Num2 + " = " + Result);
            Toast.MakeText(this, "The Result is " + Result, ToastLength.Long).Show();

            string tag = "Divide";
            Log.Info(tag, Num1.ToString());
            Log.Info(tag, Num2.ToString());
            Log.Info(tag, result);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}