## 📁 リリース版をダウンロードするには、以下にアクセスしてください。 https://github.com/InnovatorF91/AI-Chat-App/releases/tag/v1.0.0-beta

# 🧛‍♂️ Vampire's Lair

Unity製のサードパーソンシューティングサバイバルゲーム。プレイヤーは女性主人公となり、吸血鬼が跋扈する地下基地を舞台に、ゾンビの大群と戦い、シナリオを攻略し、強力なボスに挑み、最高スコアを目指します！

---

## 🎮 ゲームの特徴

- 🧟‍♂️ **感染者が大挙して押し寄せている。**：三人称視点で多数のゾンビ敵と戦う。
- 🧠 **多言語サポート**：ワンクリック英語、日本語インターフェース
- 🧨 **タイトなバトルリズム**：得点システムとカウントダウンタイマー。
- 🧛‍♂️ **BOSS 戰**：スタンドアロン・ボスの外観とブラッドUI
- 💀 **デス・レビュー**：プレイヤーが死亡した場合、最終スコアを表示。
- 💾 **記録管理**：オールタイム・ハイスコアの手動クリア

---

## 📷 遊戲畫面預覽

| 主人公の探索シーン |オープン・ファイア・インタラクティブ | グループエンカウンター | BOSS 登場 | 死亡画面 |
|--------------|----------|-------------|-------------|------------|
| ![390ef35a-b665-41c6-a499-62f754a5b759](https://github.com/user-attachments/assets/4cf5b516-50ee-48fb-8ff8-5b6c50ef24a6)|![1b8dc1cd-80d6-41f4-8d5e-6d7f95dea14e](https://github.com/user-attachments/assets/f95b1427-5adc-4895-9273-d7aad2ffc449)|![3b2958b0-3f62-4f23-8516-41ff40efac68](https://github.com/user-attachments/assets/30b4926e-71f7-41e2-938c-027b09be865c)|![58af4e93-84cb-4faf-809a-d46ced4d6a8f](https://github.com/user-attachments/assets/a0d14cb8-fbe3-4577-a5b7-575715a1ab29)|![eb74b36f-5645-407c-8ad5-5ef743ba315e](https://github.com/user-attachments/assets/6612f4af-d528-4945-b842-916180d2d918)|

---

## 🛠 技術仕様

- **ゲームエンジン**：Unity (バージョン 2020+)
- **言語**：C#
- **開発プラットフォーム**：Windows
- **キャラクタコントロール**：サード・パーソン・シューティング + マウス照準
- **使用 Asset**：
  - Mixamo 動作 / モデル
  - 無料の環境とゾンビモデルのリソース
  - UIフォントレンダリング用TextMeshPro

---

## 🧩 機能モジュール紹介

- `GameManager`：時間とステータスの管理を担当
- `PlayerController`：キャラクター移動、射撃、衝突処理
- `EnemySpawner`：敵の発生ポイントとウェーブ・デザイン
- `BossController`：ボス出現アニメーション、ライフ値コントロール、バトルロジック
- `ScoreManager`：得点の蓄積と保管
- `LanguageManager`：英語/日本語 切り替え
- `UIController`：すべてのUIボタンとシーンジャンプに対応。
- `SaveSystem`：最高得点と最短クリアタイムを保存する（ローカル）

---

## 🚀 実行方法

### Unity Editor

1. Unity Hubでプロジェクトを開始する
2. Assets/Scenes/MainMenu.unity`を実行します。
3. `Play`をタップして、完全なプロセスをテストする。

---

## 🌐 多語言預覽

| English | 日本語 |
|---------|--------|
| ![fb67712c-3c3a-4314-80b2-b8964e73a4f3](https://github.com/user-attachments/assets/74bdd551-36ce-44ab-baf3-825e616a8dd6)|  ![633b66f1-e7af-4ca2-b914-84c8fecd06d0](https://github.com/user-attachments/assets/ee5edf7a-ae02-43e5-b5c7-3dc038563c1b)|
