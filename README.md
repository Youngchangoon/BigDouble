# BigDouble

게임 내 표시하기 힘든 아주아주 큰 숫자(double)를 string으로 변환해서 보여주는 패키지입니다.
double 숫자를 string으로 변환해주는 Extensions를 사용합니다.

## Features

- Extensions
  - DoubleToFullString(): double을 콤마를 포함한 숫자로 변환해서 전부 표시합니다.
  - DoubleToShortString(): 사전 정의된 BigDoubleSetting를 참조하여 현재 key값에 맞는 숫자 형식으로 출력합니다.

## Install

- `Packages/manifest.json` 파일에 접근합니다.
- 아래와 같이 scopedRegistries를 추가하고 npm을 추가합니다.
- dependencies에 `"longman.bigdouble": "X.Y.Z"`을 추가합니다.

```
{
  "scopedRegistries": [
    {
      "name": "npmjs",
      "url": "https://registry.npmjs.org/",
      "scopes": [
        "longman"
      ]
    }
  ],

  "dependencies": {
    "longman.bigdouble": "1.0.0"
  }
}
```


## Usage

1. 상단의 `Tools/LongMan/BigDoubleSettings`를 클릭하여 파일을 생성합니다.
2. Key값과 단위의 맞게 단위들을 채웁니다.
3. double형 숫자의 Extensions함수인 `DoubleToShortString()`을 호출하여 사용합니다. 
4. Key값을 바꿀땐 `BigDoubleSettings`의 `ChangeDoubleUnits()`를 이용합니다.


## BigDoubleSettings

![image](https://user-images.githubusercontent.com/10609257/134286100-ae0f6c01-6f37-4d42-b87c-277407acbe1e.png)

- DefaultKey: 게임 실행후 Key를 변경하지 않을시 설정되는 Key.
- DoubleUnitDictionary
  - Key: 딕셔너리 식별자
  - Double Units: double 단위들
  - DigitInterval: 자릿수 간격 (한국 단위는 기본적으로 4)
  - IsPoint: 소수점 표기를 할 것인지