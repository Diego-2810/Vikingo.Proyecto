# Sistema de Expediciones Vikingas - Solución Refactorizada

## Descripción General

Se ha implementado un sistema completo y orientado a objetos de gestión de expediciones vikingas que utiliza **clases abstractas y herencia** en lugar de enums.

### Conceptos Clave Implementados

- **Polimorfismo**: `Rol` y `CastaSocial` son clases abstractas con comportamiento específico
- **Herencia**: `Soldado` y `Granjero` heredan de `Rol`; `Jarl`, `Karl`, `Thrall` heredan de `CastaSocial`
- **Encapsulación**: Cada clase maneja su propia lógica de productividad y ascenso
- **Abstracción**: `Lugar` define el contrato para todos los lugares invadibles

## Estructura del Proyecto

### Proyectos

1. **Vikingos.Core** - Biblioteca de clases (Class Library)
   - Contiene toda la lógica del dominio
   - Clases abstractas y sus implementaciones

2. **Vikingos.Core.Tests** - Proyecto de Pruebas (xUnit)
   - 9 pruebas unitarias exhaustivas
   - Todas las pruebas **PASANDO** ✓

3. **Vikingos** - Aplicación Console
   - Punto de entrada interactivo (Program.cs)
   - Demostración completa del sistema

## Componentes de la Arquitectura

### Entidad Vikingo
```
Vikingo
├── Nombre: string
├── Fuerza: int
├── Peso: int
├── Barbarie: int
├── Rol: Rol (composición)
└── Casta: CastaSocial (composición)
```

### Jerarquía de Roles
```
[Rol] (abstract)
├── EsProductivo(Vikingo) : bool
├── [Soldado]
│   ├── VidasCobradas: int
│   ├── Armas: int
│   └── Valida si: VidasCobradas > 20 AND Armas > 0
└── [Granjero]
    ├── Hijos: int
    ├── Hectareas: int
    └── Valida si: Hectareas >= Hijos * 2
```

### Jerarquía de Castas Sociales
```
[CastaSocial] (abstract)
├── AscenderCasta(Vikingo) : void
├── [Jarl] (Esclavos)
│   └── Al ascender → Karl + bonificación roleada
├── [Karl] (Casta Media)
│   └── Al ascender → Thrall
└── [Thrall] (Nobles)
    └── No escala más
```

### Bonificaciones por Ascenso

| De | A | Bonificación Soldado | Bonificación Granjero |
|---|---|---|---|
| **Jarl** | **Karl** | +10 Armas | +2 Hijos, +2 Hectáreas |
| **Karl** | **Thrall** | - | - |
| **Thrall** | - | No escala | No escala |

### Lugares a Conquistar

#### Lugar (base abstracta)
```
[Lugar] (abstract)
├── Nombre: string
├── Defensores: int
├── CalcularBotin() : double (abstract)
└── ValelaPena(int) : bool (abstract)
```

#### Implementations
- **Aldea**: Basa su botín en crucifijos (≥15 para valer la pena)
- **Capital**: Botín = Defensores × FactorRiqueza (≥3 monedas por vikingo)
- **AldeaAmurallada**: Como Aldea pero requiere mínimo de vikingos

### Expedición
```
Expedicion
├── Nombre: string
├── Vikingos: List<Vikingo>
├── Lugares: List<Lugar>
├── SubirVikingo(Vikingo) : bool
├── CantidadVikingo() : int
├── AgregarLugar(Lugar) : void
├── RealizarExpedicion() : bool
└── ObtenerResumen() : string
```

## Validaciones Implementadas

### Productividad
1. **Soldados**: Deben tener >20 vidas Y almenos 1 arma
2. **Granjeros**: Deben tener 2 hectáreas por cada hijo (0 hijos = productivo)

### Restricciones por Casta
- **Jarl**: No puede ir a expedición si tiene armas
- **Karl** y **Thrall**: Solo si es productivo según su rol

## Patrones de Diseño Utilizados

1. **Strategy**: Cada `Rol` define una estrategia diferente de productividad
2. **Template Method**: `CastaSocial` define el template de ascenso
3. **Factory Method**: Construcción de vikingos con composición
4. **Polymorphism**: Uso de clases abstractas para comportamiento genérico

## Pruebas Unitarias - Estado: ✓ 9/9 PASANDO

1. ✓ Soldado productivo puede subir
2. ✓ Soldado sin armas NO puede subir
3. ✓ Soldado con pocas vidas NO puede subir
4. ✓ Granjero productivo puede subir
5. ✓ Granjero sin hectáreas NO puede subir
6. ✓ Jarl con armas NO puede subir
7. ✓ Jarl sin armas pero soldado improductivo NO puede subir
8. ✓ Múltiples vikingos productivos se agregan correctamente
9. ✓ Mismo vikingo puede agregarse múltiples veces

## Ejecución

```bash
# Compilar
dotnet build

# Ejecutar tests
dotnet test

# Ejecutar demostración
dotnet run --project Vikingos
```

## Output de la Demostración

El programa demuestra:
- ✓ Agregación exitosa de vikingos productivos
- ✗ Rechazo de vikingos no productivos
- Gestión de lugares con diferentes requisitos
- Ascenso de casta con bonificaciones automáticas

## Archivos Clave

### Clases Abstractas y sus Implementaciones

**Rol**
- [Rol.cs](Vikingos.Core/Rol.cs) - Clase abstracta
- [Soldado.cs](Vikingos.Core/Soldado.cs) - Implementación
- [Granjero.cs](Vikingos.Core/Granjero.cs) - Implementación

**CastaSocial**
- [CastaSocial.cs](Vikingos.Core/CastaSocial.cs) - Clase abstracta
- [Jarl.cs](Vikingos.Core/Jarl.cs) - Implementación
- [Karl.cs](Vikingos.Core/Karl.cs) - Implementación
- [Thrall.cs](Vikingos.Core/Thrall.cs) - Implementación

**Lugar**
- [Lugar.cs](Vikingos.Core/Lugar.cs) - Clase abstracta
- [Aldea.cs](Vikingos.Core/Aldea.cs) - Implementación
- [AldeaAmurallada.cs](Vikingos.Core/AldeaAmurallada.cs) - Implementación
- [Capital.cs](Vikingos.Core/Capital.cs) - Implementación

**Dominio**
- [Vikingo.cs](Vikingos.Core/Vikingo.cs) - Entidad principal
- [Expedicion.cs](Vikingos.Core/Expedicion.cs) - Agregador

## Mejoras Realizadas

✓ **Conversión de enums a clases abstractas** para mayor flexibilidad
✓ **Composición sobre herencia** - Vikingo usa Rol y CastaSocial
✓ **Método CalcularBotin()** en clase Lugar
✓ **Métodos renombrados** para seguir especificación (SubirVikingo, RealizarExpedicion, CantidadVikingo)
✓ **Atributos físicos** agregados a Vikingo (Fuerza, Peso, Barbarie)
✓ **Polimorfismo completo** con comportamientos específicos por clase

## Conclusión

El sistema implementa correctamente:
- ✓ Validación compleja de productividad
- ✓ Sistema de castas con ascenso dinámico
- ✓ Gestión de expediciones y lugares
- ✓ Código limpio, testeable y extensible
- ✓ Todas las validaciones del requisito original
