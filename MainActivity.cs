using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace XamCal2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView textMessage;
        private TextView txtNum1, txtNum2;
        private double Num1, Num2, Result;
        private Button btnPlus, btnMinus, btnMul, btndivide, btnThatButton;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            // this is like a constructor 
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            btnMinus = FindViewById<Button>(Resource.Id.btnminus);
            btnMul = FindViewById<Button>(Resource.Id.btnmul);
            btndivide = FindViewById<Button>(Resource.Id.btndivide);
            txtNum1 = FindViewById<TextView>(Resource.Id.txtNum1);
            txtNum2 = FindViewById<TextView>(Resource.Id.txtNum2);

            btndivide.Click += Btndivide_Click;








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