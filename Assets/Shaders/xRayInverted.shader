Shader "Onur/xRayInverted" {
        SubShader
        {
            Tags {
                 "Queue" = "Transparent"
            }
            ZWrite off 

            Pass
            {
                ColorMask 0 
   
                Stencil {
                Ref 1 
                Comp always 
                Pass replace
                }
                
            }
            
            Pass
            {
                Blend OneMinusDstColor OneMinusSrcColor
                BlendOp Add
            }
    }
}