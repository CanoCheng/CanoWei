# ASP.NET MVC 記帳本

#### demo網址 : <a href="http://accountingbook.azurewebsites.net/AccountingBook" target="_blank">http://accountingbook.azurewebsites.net/AccountingBook</a>

## Version 1 (done)

* 必須使用Layout
* 下方列表部分建議分開，不要寫在同一頁並且要有假資料（禁止寫死在HTML）
* 上方輸入的部分可以只是切版的結果不用實現功能
* 前方數字是流水號，不是DB的值

---

## Version 2 (done)

#### 請將記帳本呈現資料的部分改為真DB (done)

* 可使用EF , ADO.NET
* 範例資料庫請使用HomeWorkDB 內的資料
* 不可改變第一天設計的ViewModel

#### 建議練習 

* 實做Service 層

####  額外挑戰 

* UnitOfWork
* Repository

#### 個人挑戰 

* IOC & DI ( 使用 Unity容器 )
* Unit of Work 生命週期調整

---

### v3.0
#### **初階版**
1. 將記帳本的寫入功能完成(完成)
2. 必須真的寫進資料庫(完成)
3. 所有欄位必填(完成)
   * 「金額」只能輸入正整數
   * 「日期」不得大於今天
   * 「備註」最多輸入100個字元（備註為 TextArea）
4. 列表加入顏色變換(完成)
   * 類型的「支出」字樣顯現為紅色
   * 類型的「收入」字樣顯現為藍色

#### **進階版**
1. 將記帳本的寫入功能改為 AJAX。(完成)
2. 你將會遇到以下問題(完成)
   * 如何片段更新下方 List
   
---
