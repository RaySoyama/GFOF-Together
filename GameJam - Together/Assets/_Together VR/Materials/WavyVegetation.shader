Shader "Unlit/WavyVegetation"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_WorldSize("World Size", vector) = (1, 1, 1, 1)
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct vertexInput
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct vertexOutput
            {
				float4 pos : SV_POSITION;
				float3 normal : NORMAL;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

			vertexOutput vert(vertexInput input) 
			{
				vertexOutput output;

				output.pos = UnityObjectToClipPos(input.vertex);
				float4 normal4 = float4(input.normal, 0.0);
				output.normal = normalize(mul(normal4, unity_WorldToObject).xyz);

				float4 worldPos = mul(input.vertex, unity_ObjectToWorld);

				return output;
			}

			float4 frag(vertexOutput input) : COLOR
			{
				return float4(0,0,0, 1.0);
			}
            ENDCG
        }
    }
}
