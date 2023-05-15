**Jolson Eric Cruz (2219359)** <br>

**Project Title:** CashFlow360 _(Modern Day Banking System)_

**Project Scope:** 

* Features of the selected project
    * Customer Onboarding: Banking staff will be able to onboard new customers to their financial institution. To support this functionality, the banking system will provide a registration form or portal that stores customer details into a database.
    * Customer Details Management: Banking staff will be able to add or modify customer details in the banking system. Similar to client onboarding, the banking system will provide a registration form or portal that allows banking staff to update the profile of their clients.
    * Balance Checking: Banking staff will have access to the entire banking portfolio of their clients. For example, account managers will be able to see the individual balances of their clients' checking and savings accounts. This functionality is supported by the banking system pulling data stored in the database through MongoDB.
    * Deposit Money: Bank tellers will be able to add funds to the individual accounts of clients. To support this functionality, the banking system will update the database with the deposited amounts.
    * Withdraw Money: Bank tellers will be able to remove funds from the individual accounts of clients. To support this functionality, the banking system will update the database with the withdrawn amounts.
    * Electronic Transfer of Money (ETF): Bank tellers will be able to transfer funds from one client's account to another. To support this functionality, the banking system will update the database with the transferred amounts.
    * Export Banking Transactions: Account managers will be able to retrieve client transactions based on specified time periods (daily, weekly, monthly, yearly, or custom). This functionality is supported by the banking system pulling banking transactions from the database based on the specified time period. 
    * Generate Statement of Accounts: Account managers will be able to generate a statement of account (SOA) using the banking transactions retrieved from clients. To support this functionality, the banking system will pull the banking transactions stored in the database and generate a PDF.
    * Account Information Storage: Banking staff will be able to update the database with up-to-date personal information, account balances, and more. To implement this functionality, the banking system will provide a form similar to client onboarding, allowing banking staff to modify existing values stored in the database.
    * Banking Transaction Storage: Banking staff will be able to update the database with up-to-date banking transactions that reflect in a client's transaction history. This functionality is supported by a form provided by the banking system, similar to updating account information.
    * Printer Connectivity: Banking staff will be able to connect to local or network printers to efficiently print the generated reports provided by the banking system.
* End users
    * Bank Managers: These employees are responsible for overseeing the operations of a single branch within the financial institution. Their role includes auditing financial transactions to ensure compliance with corporate policies, provincial government regulations, and federal government laws. For example, bank managers verify the legitimacy of transactions to ensure adherence to Anti Money Laundering (AML) laws.
    * Account Managers: These employees are responsible for managing the banking portfolios of clients within the branch. Account managers serve as the main point of contact for clients regarding their accounts and handle tasks such as onboarding new clients and modifying customer details.
    * Bank Tellers: These employees are responsible for conducting transactional operations, including depositing, withdrawing, and transferring money. Bank tellers interact directly with customers and handle the disbursement and receipt of funds.
    * Customer Support Agents: These employees provide remote assistance to customers through phone support or live chat. Customer support agents handle customer inquiries and perform transactional operations remotely, often utilizing telephone banking.
* Integration of the End users with the project (user stories)
    * End users such as bank managers, account managers, bank tellers, and customer support agents will be able to use the banking system to provide a seamless, efficient, and streamlined banking experience for their clients.
* Areas covered with this project
    * Account management: The banking system will provide implementing banks with easy user management features such as: 
        * creating account
        * updating information
        * depositing and withdrawing
        * generating reports and statements
    * Transactions: The banking system will provide implementing banks with the ability to efficiently display transactions, sort them, and export them as Statement of Accounts.
    * Banking Operations: The banking system will provide implementing banks with basic banking operations such as depositing, withdrawing, and transferring money.
    * Networking and Data Storage: The banking system will provide implementing banks with the ability to securely store data in a remote database.
    * Connectivity: The banking system will provide implementing banks with the ability to connect to a local printer to print reports.

**Project Users:** 

As a modern-day banking system, CashFlow360 offers valuable assistance to financial institutions seeking to streamline their operations and improve efficiency. The system provides a unified platform for storing account and banking information, conducting money management operations (such as deposits, withdrawals, and transfers), and generating instant banking reports as needed.

For example, bank managers can effectively utilize the system to conduct transactional audits between clients and tellers, streamlining branch operations. Account managers benefit from an all-in-one system that enables efficient handling of their clients' banking needs. Bank tellers can utilize the system to perform various transactional operations, including depositing money, cashing checks, withdrawing funds, and conducting telegraphic or electronic transfers. Lastly, customer service agents can leverage the banking system to provide seamless telephone banking services to clients in need.

**Project Actuator:**

Banking Institutions will play an integral role in the implementation of CashFlow360. As a Modern Day Banking System, banking institutions will have to review and approve the proposed system to have its clients (and staff) benefit from the streamlined features it provides. Without the review and approval of banking institutions, CashFlow360 would not be able to identify the individual and unique features that implementing banking institutions require. For instance, not all banks provide the same banking products to its clients; thus, not all banking institutions will require the same set of features from our system. A real-life example of such a scenario is HSBC’s ability to instantly transfer funds from any HSBC account in its servicing countries without the need of wire or telegraphic transfer. Furthermore, CIBC provides their clients with the ability to instantly check their Equifax credit score without the need of paying for a credit check nor risking a hard inquiry.

**Project Vendors:**

CashFlow360 is an open-source banking system provided by Jolson Cruz. Jolson is a postgraduate student from Vanier College taking up an Attestation of Collegial Studies diploma in Software Development: Secure Desktop, Mobile and Web Applications Attestation. It is a full-time technical training program designed for an adult clientele who already have an educational or working background, but who wish to upgrade their skills at a higher educational level. They are developed by colleges in Quebec in collaboration with labor market partners to ensure they meet the needs of the workforce. Attestations are recognized by the Quebec Ministry of Education, and are highly regarded by employers and various licensing and certification boards. Courses focus on core subjects and relevant, real-world training.

Moreover, Jolson originated from the Philippines wherein he took-up a Bachelors of Science in Computer Science with Specialization in Network Engineering at De La Salle University in Manila, Philippines. He graduated last 2022 with an undergraduate thesis related to novel-based security protocols in Wireless Sensor Networks.


**Project Actors:** 

CashFlow360’s is a tool that will be heavily used by both banking Institutions and their respective clients. With the rich features the system provides, both banking staff and clients will benefit from streamlined banking operations, user-friendly experience, and easy onboarding. The banking system takes into account the various day-to-day operations of banking institutions and provides solutions to address their common struggles and challenges in fulfilling the unique banking needs of each client.

To deliver a fully user-friendly experience and ensure easy onboarding, an easy-to-follow user documentation is accompanied in this project. Interested banking institutions will simply have to follow the deployment manual provided in the documentation and supply the user guide to its clients _(if necessary)_. Moreover, banking institutions have the ability to customize the banking system to address their specific needs. For instance, banking institutions can white-label CashFlow360 by incorporating the bank’s official colors, logo, and branding to the system.

**Project Properties:**

* C#: A programming language created by Microsoft's Anders Hejlsberg in 2000.
* .NET Framework: A development platform created by Microsoft in 2002.
* MongoDB (Database): A NoSQL database thaw was founded by Dwight Merriman, Eliot Horowitz and Kevin Ryan in 2007.
* System.Drawing: A C# namespace that provides basic GUI and GDI functionality in .NET. .

**Plan Details:**

<table>
  <tr>
   <td>Project Task
   </td>
   <td>Proposed Deadline
   </td>
  </tr>
  <tr>
   <td>

<li>Implement the system as a console application and test its functionalities
</li>
   </td>
   <td>
      May 29, 2023
   </td>
  </tr>
  <tr>
   <td>

<li>Transform the source code to abide with object oriented programming
</li>
   </td>
   <td>
      June 2, 2023
   </td>
  </tr>
  <tr>
   <td>

<li>Connect MongoDB database to the application via API
</li>
   </td>
   <td>
      June 5, 2023
   </td>
  </tr>
  <tr>
   <td>

<li>Test CRUD (Create, Read, Update, Delete) functionalities to ensure the proper connection of the database with the application
</li>
   </td>
   <td>
      June 7, 2023
   </td>
  </tr>
  <tr>
   <td>

<li>Create a GUI (Graphical User Interface) for the application
</li>
   </td>
   <td>
      June 17, 2023
   </td>
  </tr>
  <tr>
   <td>

<li>Implement and test printer functionality
</li>
   </td>
   <td>
      June 23, 2023
   </td>
  </tr>
  <tr>
   <td>

<li>Project Presentation
</li>
   </td>
   <td>
      July 3, 2023
   </td>
  </tr>
</table>
