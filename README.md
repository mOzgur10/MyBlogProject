✳️ Please read before running the application
***********************************************
About MyBlog.UI/appsettings.json Configuration
***********************************************

Before running the application, make sure to set a valid connection string according to your SQL Server setup.

ℹ️ Note: This project uses Entity Framework Core with Code First approach. Ensure that your database exists (or can be created), and migrations are properly applied before use.

If you want to test or enable the email functionalities (e.g., password reset or email confirmation after registration), set "UseEmailService" to true and fill in all required SMTP configuration fields.

When the email service is disabled (false), features like "Forgot Password" on the login page will not work.

⚠️ Important: If you are using Gmail as your SMTP provider, you must generate and use an App Password instead of your regular Gmail password. This is required due to Google’s security policies.

🛠️ After running the application for the first time:

Log in using the default admin account:
Email: admin@example.com
Password: 123

Navigate to the Admin Panel.

Before creating any posts, make sure to add at least one category from the "Categories" section. Posts require a category to be selected.

