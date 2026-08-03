# WinForms 턴제 전투 게임 제작 기록

이 문서는 Codex와 대화하며 만든 WinForms 턴제 전투 게임의 구조, 코드의 역할, 구현 과정과 다음 개발 계획을 정리한 기록이다.

Visual Studio 프로젝트 파일 자체는 포함하지 않는다. 다른 컴퓨터에서는 이 문서를 참고하면서 USB로 옮긴 WinForms 프로젝트를 이어서 개발하면 된다.

## 1. 만들고 있는 게임

게임의 기본 진행은 다음과 같다.

    시작 화면
    → 전투 시작
    → 플레이어 행동
    → 적 행동
    → 승리 또는 패배
    → 다시하기 또는 홈으로

플레이어가 선택할 수 있는 행동은 현재 두 가지다.

- 공격하기: 적에게 피해를 준 뒤, 적이 살아 있으면 반격한다.
- 회복하기: 플레이어 체력을 회복한 뒤 적이 공격한다.

플레이어와 적의 공격 피해량은 각각 공격할 때마다 5~20 사이에서 무작위로 결정한다.

## 2. Form 구성

현재 Form 이름을 그대로 사용하면 다음과 같은 역할이다.

| Form | 역할 |
|---|---|
| Form1 | 게임 시작 화면 |
| Form2 | 전투 화면 |
| Form3 | 승리·패배 결과 화면 |
| Form4 | 일시정지 메뉴 |

나중에 코드를 정리할 때는 다음처럼 이름을 변경하면 읽기 쉽다.

| 현재 이름 | 권장 이름 |
|---|---|
| Form1 | StartForm |
| Form2 | BattleForm |
| Form3 | ResultForm |
| Form4 | PauseForm |

## 3. 시작 화면

시작 화면에는 다음 컨트롤이 있다.

- 게임 제목
- 전투 시작 버튼
- 종료 버튼

전투 시작 버튼을 누르면 시작 화면을 숨기고 Form2를 대화상자로 연다.

    private void btnStart_Click(object sender, EventArgs e)
    {
        Hide();

        using (Form2 battleForm = new Form2())
        {
            battleForm.ShowDialog();
        }

        Show();
    }

실행 순서:

1. Hide()로 기존 시작 화면을 숨긴다.
2. new Form2()로 전투 화면을 만든다.
3. ShowDialog()로 전투 화면을 표시한다.
4. Form2가 닫히면 Show()를 실행해 기존 시작 화면을 다시 표시한다.

Form2에서 새로운 Form1을 만들면 시작 화면이 중복 생성되므로, 홈으로 이동할 때는 Form2만 닫는다.

## 4. 전투 화면

전투 화면에는 다음 컨트롤이 있다.

- 플레이어 이름
- 플레이어 체력바
- 플레이어 현재 체력과 최대 체력
- 적 이름
- 적 체력바
- 적 현재 체력과 최대 체력
- 공격 버튼
- 회복 버튼
- 전투 메시지 TextBox
- 일시정지 메뉴를 여는 설정 아이콘

권장 컨트롤 이름:

| 역할 | 권장 Name |
|---|---|
| 플레이어 체력바 | pbPlayerHp |
| 적 체력바 | pbEnemyHp |
| 플레이어 체력 Label | lblPlayerHp |
| 적 체력 Label | lblEnemyHp |
| 공격 버튼 | btnAttack |
| 회복 버튼 | btnHeal |
| 설정 버튼 | btnSettings |
| 전투 메시지 | textBox1 또는 rtbBattleLog |

전투 메시지용 TextBox는 다음 속성을 사용한다.

    Multiline  = True
    ReadOnly   = True
    ScrollBars = Vertical

줄바꿈에는 "\n"만 사용하는 것보다 Environment.NewLine을 사용하는 것이 안전하다.

    textBox1.AppendText(
        "전투가 시작되었습니다."
        + Environment.NewLine);

## 5. 게임 데이터

Label이나 ProgressBar는 값을 보여주는 화면일 뿐이다. 실제 체력은 별도의 변수에 저장해야 한다.

Form2 클래스 안쪽, 버튼 이벤트 바깥에 다음과 같은 필드를 둔다.

    private int playerMaxHp = 100;
    private int playerHp;

    private int enemyMaxHp = 80;
    private int enemyHp;

    private int playerHealAmount = 20;

    private readonly Random random = new Random();

필드를 버튼 이벤트 바깥에 두는 이유는 공격 버튼을 누른 뒤에도 변경된 체력을 계속 기억해야 하기 때문이다.

Random 객체도 한 번만 만들어 플레이어와 적이 함께 사용한다. 공격할 때마다 new Random()을 만들지 않는다.

## 6. 전투 초기화

Form2가 처음 열리거나 다시하기를 선택했을 때 ResetBattle()을 실행한다.

    private void ResetBattle()
    {
        playerHp = playerMaxHp;
        enemyHp = enemyMaxHp;

        pbPlayerHp.Maximum = playerMaxHp;
        pbEnemyHp.Maximum = enemyMaxHp;

        btnAttack.Enabled = true;
        btnHeal.Enabled = true;

        textBox1.Clear();
        textBox1.AppendText(
            "전투가 시작되었습니다."
            + Environment.NewLine);

        UpdateBattleScreen();
    }

Form2 생성자에서는 화면 컨트롤을 먼저 만든 뒤 전투를 초기화한다.

    public Form2()
    {
        InitializeComponent();
        ResetBattle();
    }

InitializeComponent()보다 먼저 ResetBattle()을 호출하면 아직 생성되지 않은 체력바나 TextBox를 사용하게 되므로 순서를 바꾸면 안 된다.

## 7. 화면 갱신

체력 변수가 바뀌었을 때 Label과 ProgressBar도 변경해야 한다.

    private void UpdateBattleScreen()
    {
        pbPlayerHp.Value = playerHp;
        pbEnemyHp.Value = enemyHp;

        lblPlayerHp.Text = $"{playerHp}/{playerMaxHp}";
        lblEnemyHp.Text = $"{enemyHp}/{enemyMaxHp}";
    }

공격이나 회복으로 playerHp 또는 enemyHp를 변경한 뒤에는 UpdateBattleScreen()을 호출한다.

## 8. 플레이어 공격

공격 버튼을 누를 때마다 5~20 사이의 피해량을 새로 만든다.

    private void btnAttack_Click(object sender, EventArgs e)
    {
        if (enemyHp <= 0 || playerHp <= 0)
        {
            return;
        }

        int playerDamage = random.Next(5, 21);

        enemyHp -= playerDamage;

        if (enemyHp < 0)
        {
            enemyHp = 0;
        }

        textBox1.AppendText(
            $"플레이어가 적에게 {playerDamage}의 피해를 입혔습니다."
            + Environment.NewLine);

        UpdateBattleScreen();

        if (enemyHp == 0)
        {
            textBox1.AppendText(
                "몬스터를 쓰러뜨렸습니다!"
                + Environment.NewLine);

            btnAttack.Enabled = false;
            btnHeal.Enabled = false;

            ShowBattleResult("승리");
            return;
        }

        EnemyTurn();
    }

random.Next(5, 21)에서 최솟값 5는 포함되고 최댓값 21은 포함되지 않는다. 따라서 실제 결과는 5~20이다.

몬스터가 죽었다면 return으로 메서드를 끝낸다. 이 return이 없으면 죽은 몬스터가 플레이어를 반격할 수 있다.

## 9. 적의 턴

플레이어가 공격하거나 회복한 뒤 EnemyTurn()을 호출한다.

    private void EnemyTurn()
    {
        if (enemyHp <= 0 || playerHp <= 0)
        {
            return;
        }

        int enemyDamage = random.Next(5, 21);

        playerHp -= enemyDamage;

        if (playerHp < 0)
        {
            playerHp = 0;
        }

        textBox1.AppendText(
            $"적이 플레이어에게 {enemyDamage}의 피해를 입혔습니다."
            + Environment.NewLine);

        UpdateBattleScreen();

        if (playerHp == 0)
        {
            textBox1.AppendText(
                "플레이어가 죽었습니다."
                + Environment.NewLine);

            btnAttack.Enabled = false;
            btnHeal.Enabled = false;

            ShowBattleResult("패배");
        }
    }

EnemyTurn()을 별도 메서드로 만든 이유는 공격 버튼과 회복 버튼에서 같은 적 공격 코드를 반복하지 않기 위해서다.

## 10. 회복

플레이어가 회복하면 최대 체력을 넘지 않도록 제한하고, 실제로 회복된 양을 출력한다.

    private void btnHeal_Click(object sender, EventArgs e)
    {
        if (playerHp <= 0 || enemyHp <= 0)
        {
            return;
        }

        if (playerHp >= playerMaxHp)
        {
            textBox1.AppendText(
                "이미 체력이 가득 차 있습니다."
                + Environment.NewLine);

            return;
        }

        int hpBeforeHeal = playerHp;

        playerHp += playerHealAmount;

        if (playerHp > playerMaxHp)
        {
            playerHp = playerMaxHp;
        }

        int actualHealAmount = playerHp - hpBeforeHeal;

        textBox1.AppendText(
            $"플레이어가 체력을 {actualHealAmount} 회복했습니다."
            + Environment.NewLine);

        UpdateBattleScreen();
        EnemyTurn();
    }

예를 들어 현재 체력이 90이고 회복량이 20이면 계산상 110이지만 최대 체력 100으로 제한한다. actualHealAmount는 100 - 90이므로 실제 회복량 10을 출력한다.

현재 규칙에서는 체력이 가득 찬 상태로 회복 버튼을 누르면 턴을 사용하지 않으며 적도 공격하지 않는다.

## 11. 일시정지 메뉴

설정 아이콘을 누르면 Form4가 열리고 다음 버튼이 표시된다.

- 계속하기
- 다시하기
- 홈으로

Form4의 권장 속성:

    StartPosition   = CenterParent
    FormBorderStyle = FixedDialog
    MaximizeBox     = False
    MinimizeBox     = False
    ShowInTaskbar   = False

일시정지 메뉴의 선택 종류:

    public enum PauseChoice
    {
        Continue,
        Retry,
        Home
    }

Form4 안에는 선택 결과를 저장하는 속성을 둔다.

    public PauseChoice SelectedChoice { get; private set; }
        = PauseChoice.Continue;

초깃값을 Continue로 두면 사용자가 오른쪽 위 X를 눌러도 전투로 돌아간다.

각 버튼은 선택을 저장한 뒤 Form4를 닫는다.

    private void btnContinue_Click(object sender, EventArgs e)
    {
        SelectedChoice = PauseChoice.Continue;
        Close();
    }

    private void btnRetry_Click(object sender, EventArgs e)
    {
        SelectedChoice = PauseChoice.Retry;
        Close();
    }

    private void btnHome_Click(object sender, EventArgs e)
    {
        SelectedChoice = PauseChoice.Home;
        Close();
    }

Form2의 설정 버튼에서는 Form4가 닫힌 뒤 선택 결과를 확인한다.

    private void btnSettings_Click(object sender, EventArgs e)
    {
        using (Form4 pauseForm = new Form4())
        {
            pauseForm.StartPosition = FormStartPosition.CenterParent;
            pauseForm.ShowDialog(this);

            if (pauseForm.SelectedChoice == PauseChoice.Retry)
            {
                ResetBattle();
            }
            else if (pauseForm.SelectedChoice == PauseChoice.Home)
            {
                Close();
            }
        }
    }

ShowDialog(this)의 this는 현재 Form2를 의미한다. Form4를 Form2의 모달 자식 창으로 열기 때문에 전투 화면 중앙에 표시되고, Form4가 열려 있는 동안 뒤쪽 전투 화면을 클릭할 수 없다.

## 12. 결과 화면

Form3에는 다음 요소가 있다.

- 승리 또는 패배를 표시하는 Label
- 다시하기 버튼
- 홈으로 버튼

전투 결과 Label의 권장 이름은 lblBattleResult이다.

Form3에서 결과 Label을 변경하는 메서드:

    public void SetBattleResult(string resultText)
    {
        lblBattleResult.Text = resultText;
    }

Form2는 Form3을 표시하기 전에 결과를 전달한다.

    private void ShowBattleResult(string resultText)
    {
        using (Form3 form3 = new Form3())
        {
            form3.SetBattleResult(resultText);

            DialogResult result = form3.ShowDialog(this);

            if (result == DialogResult.Yes)
            {
                ResetBattle();
            }
            else if (result == DialogResult.No)
            {
                Close();
            }
        }
    }

승리할 때:

    ShowBattleResult("승리");

패배할 때:

    ShowBattleResult("패배");

Form3의 다시하기 버튼은 DialogResult.Yes, 홈으로 버튼은 DialogResult.No를 반환하도록 설정한다.

## 13. 자주 발생했던 문제

### 버튼을 눌러도 반응이 없음

메서드를 작성했더라도 버튼의 Click 이벤트에 연결되지 않았을 수 있다.

디자이너에서 버튼을 선택한 뒤 다음을 확인한다.

    속성 창
    → 번개 아이콘
    → Click
    → 사용할 클릭 메서드 선택

또는 버튼 이벤트 첫 줄에 임시로 다음 코드를 넣어 실행 여부를 확인할 수 있다.

    MessageBox.Show("버튼 이벤트 실행");

### enemyHp가 처음부터 0임

int 필드는 값을 넣지 않으면 기본값이 0이다. Form2 생성자에서 ResetBattle()을 호출하고, ResetBattle() 안에서 다음 코드가 실행되어야 한다.

    enemyHp = enemyMaxHp;

화면 Label에 80/80이라고 직접 적어두는 것과 실제 enemyHp 변수에 80을 저장하는 것은 서로 다른 작업이다.

### 메시지가 한 줄로 이어짐

TextBox의 Multiline 속성을 True로 설정하고 메시지 끝에 Environment.NewLine을 붙인다.

    textBox1.AppendText(
        "새로운 전투 메시지"
        + Environment.NewLine);

### 체력 변수는 감소하지만 체력바가 변하지 않음

UpdateBattleScreen()이 실제로 감소시키는 변수와 같은 이름을 사용하는지 확인한다. 공격 코드가 enemyHp를 사용한다면 화면 갱신 코드도 enemyHp를 사용해야 한다.

## 14. 다음 확장 계획

기본 전투가 완성되면 스테이지와 강화 시스템을 추가할 계획이다.

추천 게임 흐름:

    게임 시작
    → 스테이지 1
    → 승리
    → 강화 선택
    → 스테이지 2
    → 반복
    → 최종 스테이지 또는 패배

### 스테이지 강화 예시

| 스테이지 | 몬스터 | 체력 | 피해량 |
|---:|---|---:|---:|
| 1 | 슬라임 | 80 | 5~20 |
| 2 | 고블린 | 110 | 7~23 |
| 3 | 오크 | 140 | 9~26 |
| 4 | 골렘 | 170 | 11~29 |
| 5 | 보스 | 220 | 14~34 |

계산식 예시:

    몬스터 최대 체력
    = 80 + (현재 스테이지 - 1) × 30

    몬스터 최소 공격력
    = 5 + (현재 스테이지 - 1) × 2

    몬스터 최대 공격력
    = 20 + (현재 스테이지 - 1) × 3

### 강화 선택 예시

- 무기 강화: 플레이어 최소·최대 피해량 증가
- 체력 강화: 플레이어 최대 체력 20 증가
- 회복 강화: 회복량 5 증가

권장 구현 순서:

1. currentStage 변수 추가
2. 전투 화면에 현재 스테이지 표시
3. 스테이지에 따라 몬스터 체력과 공격력 증가
4. 승리 결과창에서 다음 스테이지 선택
5. 다음 스테이지가 정상적으로 시작되는지 확인
6. UpgradeForm 추가
7. 무기·체력·회복 강화 중 하나를 선택하도록 구현

앞으로는 다음 메서드의 역할을 구분하는 것이 좋다.

| 메서드 | 역할 |
|---|---|
| StartNewGame() | 스테이지와 모든 강화를 초기화하고 새 게임 시작 |
| ResetBattle() | 현재 스테이지를 같은 조건으로 다시 시작 |
| StartNextStage() | 스테이지를 1 증가시키고 더 강한 적과 전투 시작 |

## 15. 다음 작업

현재 기본 전투, 회복, 적의 반격, 일시정지, 승패 결과창까지 구현한 상태다.

다음 작업은 currentStage 변수를 추가하고, 전투 화면에 현재 스테이지를 표시하는 것이다. 이후 몬스터의 체력과 공격 범위를 스테이지 계산식에 연결한다.
