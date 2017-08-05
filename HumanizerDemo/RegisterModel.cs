namespace HumanizerDemo
{
  class RegisterModel
  {
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public string ConfirmPassword { get; set; }

    //instead of
    /*
    [Display(Name = "User name")]
    public string UserName { get; set; }

    [Display(Name = "Email address")]
    public string EmailAddress { get; set; }

    [Display(Name = "Confirm password")]
    public string ConfirmPassword { get; set; }
    */
  }
}