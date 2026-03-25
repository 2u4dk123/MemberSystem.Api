# Member Management System (Backend Architecture Practice)

這是一個基於 **.NET 8** 開發的會員管理系統後端架構練習專案。本專案不僅實作了基礎的註冊與登入功能，更重點在於導入現代化 Web 開發的架構設計原則與資安規範。

---

### 📝 專案摘要
* **專案職責：** Backend Engineer (獨立開發)
* **核心目標：** 建立高安全性、可擴展之認證系統，並透過分層架構確保維運靈活性。

---

### 🚀 技術亮點與執行內容

#### 1. 系統分層架構設計 (Service-Repository Pattern)
實作分離式架構，將 **商業邏輯 (Service)** 與 **資料存取 (Repository)** 徹底解耦。此設計優化了程式碼的可測試性，並確保未來更換資料庫層時具備高度彈性。

#### 2. 定義 RESTful API 規格與資料轉換 (DTO)
設計標準化 API 接口，並透過 **DTO (Data Transfer Object)** 模式進行資料對映，物理性隔絕 PII (個人識別資訊) 安全性，確保敏感資訊（如 PasswordHash）不會流向前端。

#### 3. 現代化安全認證與加密
* **密碼安全：** 整合 **BCrypt** 雜湊演算法進行規格化加密存儲。
* **認證機制：** 實作 **JWT (JSON Web Token)** 無狀態認證流程，取代傳統 Session，降低伺服器開銷並支援跨平台擴展。

#### 4. 全域異常處理 (Middleware)
利用 .NET **Middleware** 機制開發全域攔截器，統一全站 API 報錯格式。在確保系統穩定性的同時，為前端提供精確的 Debug 資訊，並隱藏底層伺服器路徑。

#### 5. 異常日誌自動化紀錄與維運管理
於 Middleware 整合 Logging 機制，確保系統錯誤具備 **Traceability (可追蹤性)**。導入日誌管理意識，以縮短故障排除時間，並為未來實作 Rolling Logs 預留擴充接口。

---

### 🛠️ 技術棧 (Tech Stack)
* **Framework:** .NET 8 Web API
* **ORM:** Entity Framework Core (Code-First)
* **Database:** MySQL
* **Security:** JWT Authentication, BCrypt.Net
* **Frontend Interaction:** AJAX (Fetch API)
* **API Documentation:** Swagger (OpenAPI)
