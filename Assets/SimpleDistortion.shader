Shader "Custom/SimpleDistortion" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Amount ("���������", Range(0, 0.1)) = 0.02
    }
    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Amount;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                // ������� ��������� "�������"
                float2 uv = i.uv;
                uv.x += sin(uv.y * 20 + _Time.y) * _Amount;
                return tex2D(_MainTex, uv);
            }
            ENDCG
        }
    }
}