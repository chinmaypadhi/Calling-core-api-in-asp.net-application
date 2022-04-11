using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calling_CORE_API_IN_ASP_APPLICATION
{
    public partial class Calling_CORE_API_IN_ASP_APPLICATION : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack != true)
            {
                FillDATA();
                Bind();
                using (var httpClient = new HttpClient())
                {
                    string filePath = ConfigurationManager.AppSettings["localpath"].ToString();
                    //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", modal.token);
                    using (var response = httpClient.GetAsync(filePath + "api/values/getAllData"))
                    {
                        var apiResponse = response.Result.Content.ReadAsStringAsync().Result;
                        ListData HouseholddataList = JsonConvert.DeserializeObject<ListData>(apiResponse);
                        if (HouseholddataList.status == "200")
                        {

                            GridView1.Visible = true;
                            DataTable dtMember = new DataTable();
                            dtMember.Columns.Add("Name");
                            dtMember.Columns.Add("City");
                            foreach (var list in HouseholddataList.infoData)
                            {
                                DataRow dr = dtMember.NewRow();
                                dr["Name"] = list.name;
                                dr["City"] = list.city;
                                dtMember.Rows.Add(dr);
                                GridView1.DataSource = dtMember;
                                GridView1.DataBind();
                                Label1.Text = "Data Showing Successfully";
                            }
                        }
                            else
                            {
                                Label1.Text = response.Result.ReasonPhrase;
                            }
                        

                    }


                }
            }
        }

        public void FillDATA()
        {
            using (var httpClient = new HttpClient())
            {
                string filePath = ConfigurationManager.AppSettings["localpath"].ToString();
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", modal.token);
                using (var response = httpClient.GetAsync(filePath + "api/values/getAllData"))
                {
                    var apiResponse = response.Result.Content.ReadAsStringAsync().Result;
                    ListData HouseholddataList = JsonConvert.DeserializeObject<ListData>(apiResponse);
                    if (HouseholddataList.status == "200")
                    {

                        GridView1.Visible = true;
                        DataTable dtMember = new DataTable();
                        dtMember.Columns.Add("Name");
                        dtMember.Columns.Add("City");
                        foreach (var list in HouseholddataList.infoData)
                        {
                            DataRow dr = dtMember.NewRow();
                            dr["Name"] = list.name;
                            dr["City"] = list.city;
                            dtMember.Rows.Add(dr);
                            GridView1.DataSource = dtMember;
                            GridView1.DataBind();
                            Label1.Text = "Data Showing Successfully";
                        }
                    }
                    else
                    {
                        Label1.Text = response.Result.ReasonPhrase;
                    }


                }


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListData alldeatails = new ListData();
           // UpdateHouseholdDto obd = new UpdateHouseholdDto();
            List<info> objlist = new List<info>();
            List<string> ob = new List<string>();
            foreach (GridViewRow gvr in GridView2.Rows)
            {
                string name = ((TextBox)gvr.FindControl("name")).Text;
                string city = ((TextBox)gvr.FindControl("city")).Text;

                info obj = new info
                {
                    name = name,city=city
                };

                objlist.Add(obj);
            }
            
            alldeatails.infoData= objlist;
            get(alldeatails);
            FillDATA();
        }
        private void Bind()
        {

            createGrid obj = new createGrid() { id = 1 };
            createGrid obj2 = new createGrid() { id = 2 };
            createGrid obj3 = new createGrid() { id = 3 };
            createGrid obj4 = new createGrid() { id = 4 };
            createGrid obj5 = new createGrid() { id = 5 };
            List<createGrid> objgrd = new List<createGrid>();
            objgrd.Add(obj);
            objgrd.Add(obj2);
            objgrd.Add(obj3);
            objgrd.Add(obj4);
            objgrd.Add(obj5);
            GridView2.DataSource = objgrd;
            GridView2.DataBind();

        }



        public void get(ListData modal)
        {
            string filePath = ConfigurationManager.AppSettings["localpath"].ToString();
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.PostAsJsonAsync(filePath + "api/values/addMoreData", modal.infoData))
                {
                    var apiResponse = response.Result.Content.ReadAsStringAsync().Result;

                    if (response.Result.IsSuccessStatusCode == false)
                    {
                        Label2.Text = response.Result.ReasonPhrase;

                    }
                    else
                    {
                        DataList HouseholddataList = JsonConvert.DeserializeObject<DataList>(apiResponse);
                        //if (HouseholddataList.status != "500")
                        //{
                        //    Label1.Text = HouseholddataList.message;

                        //}
                        //else
                        //{
                        //    Label1.Text = "Invalid Input";
                        //}

                    }



                }
            }


        }

    }
}