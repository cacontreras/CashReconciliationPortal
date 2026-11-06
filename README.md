# Cash Reconciliation Portal

A web-based portal developed in ASP.NET Core 8 (MVC/API) to manage and audit daily cash deposits, ensuring strict separation of concerns through a layered architecture (BLL, DAL).

## Completed Deliverables
* **Core Application:** Full functional dashboard for deposit reconciliation.
* **Internationalization (i18n):** Complete English and Spanish UI support.
* **Bonus Feature:** Audit Trail implementation with historical timeline[span_6](start_span)[span_6](end_span).

> **Note to Evaluator:** An attempt at the "Server-side Pagination" bonus feature[span_7](start_span)[span_7](end_span) is currently preserved in the `feature/server-side-pagination` branch. It was intentionally left out of the `main` branch to guarantee the stability of the core deliverable.

## Setup Instructions

### Prerequisites
* .NET 8 SDK
* SQL Server
* Visual Studio 2022 (recommended) or VS Code

### Installation Steps
1. **Clone the repository:**
   `git clone https://github.com/cacontreras/CashReconciliationPortal.git`
2. **Database Setup:**
   * Option A: Execute the provided SQL script `CashReconciliation_Schema.sql` in your SQL Server instance.
   * Option B: Open the Package Manager Console and run `Update-Database` to apply Entity Framework Core migrations.
3. **Configuration:**
   Update the `DefaultConnection` string inside `appsettings.json` to point to your local SQL Server instance.
4. **Run the Application:**
   Build and run the solution. The application will launch in your default browser.