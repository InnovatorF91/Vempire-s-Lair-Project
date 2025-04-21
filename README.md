![58af4e93-84cb-4faf-809a-d46ced4d6a8f](https://github.com/user-attachments/assets/91d6434f-3308-4619-96f8-a249cc29cd06)# 🧛‍♂️ Vampire's Lair

一款 Unity 製作的第三人稱射擊生存遊戲。玩家將扮演一位女主角，在吸血鬼盤踞的地下基地中殺出重圍，與成群殭屍搏鬥、破解場景機關、挑戰強力 BOSS，並努力取得最高分數！

---

## 🎮 遊戲特色

- 🧟‍♂️ **感染者蜂擁而至**：以第三人稱視角對抗大量殭屍敵人
- 🧠 **多語言支援**：一鍵切換中英日介面
- 🧨 **緊張戰鬥節奏**：具備射擊得分系統與存活倒計時
- 🧠 **機關互動**：可與場景機械物件互動觸發劇情
- 🧛‍♂️ **BOSS 戰**：獨立 BOSS 登場演出與血條 UI
- 💀 **死亡回顧**：玩家死亡後展示最終得分，可重新挑戰
- 💾 **紀錄管理**：可手動清除歷史最高分紀錄

---

## 📷 遊戲畫面預覽

| 主角探索場景 | 開火互動 | 團體遭遇戰 | BOSS 登場 | 死亡畫面 |
|--------------|----------|-------------|-------------|------------|
| ![390ef35a-b665-41c6-a499-62f754a5b759](https://github.com/user-attachments/assets/4cf5b516-50ee-48fb-8ff8-5b6c50ef24a6)
|  ![1b8dc1cd-80d6-41f4-8d5e-6d7f95dea14e](https://github.com/user-attachments/assets/f95b1427-5adc-4895-9273-d7aad2ffc449)
| ![3b2958b0-3f62-4f23-8516-41ff40efac68](https://github.com/user-attachments/assets/30b4926e-71f7-41e2-938c-027b09be865c)
|![58af4e93-84cb-4faf-809a-d46ced4d6a8f](https://github.com/user-attachments/assets/a0d14cb8-fbe3-4577-a5b7-575715a1ab29)
|![eb74b36f-5645-407c-8ad5-5ef743ba315e](https://github.com/user-attachments/assets/6612f4af-d528-4945-b842-916180d2d918)|

---

## 🛠 技術規格

- **引擎**：Unity (版本 2022+)
- **語言**：C#
- **開發平台**：Windows（支援打包為 .exe）
- **角色控制**：第三人稱射擊 + 滑鼠瞄準
- **使用 Asset**：
  - Mixamo 動作 / 模型
  - 免費環境與殭屍模型資源
  - TextMeshPro 做 UI 字體渲染

---

## 🧩 功能模組簡介

- `GameManager`：負責時間與狀態控制
- `PlayerController`：角色移動、開火、碰撞處理
- `EnemySpawner`：敵人生成點與波次設計
- `BossController`：BOSS 出現動畫、血條控制與戰鬥邏輯
- `ScoreManager`：分數累計與儲存
- `LanguageManager`：切換 English / 日本語 介面
- `UIController`：對應所有 UI 按鈕與場景跳轉
- `SaveSystem`：儲存最高分數與最短通關時間（本地）

---

## 🚀 執行方式

### 透過 Unity 編輯器執行

1. 使用 Unity Hub 開啟專案
2. 執行 `Assets/Scenes/MainMenu.unity`
3. 點選 `Play` 測試完整流程

---

## 🌐 多語言預覽

| English | 日本語 |
|---------|--------|
| ![fb67712c-3c3a-4314-80b2-b8964e73a4f3](https://github.com/user-attachments/assets/74bdd551-36ce-44ab-baf3-825e616a8dd6)|  ![633b66f1-e7af-4ca2-b914-84c8fecd06d0](https://github.com/user-attachments/assets/ee5edf7a-ae02-43e5-b5c7-3dc038563c1b)|
