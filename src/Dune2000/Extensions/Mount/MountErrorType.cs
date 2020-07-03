namespace Dune2000.Extensions.Mount
{
  public enum MountErrorType
  {
    SUCCESS = 0,
    // init errors
    CONFIG_NOTFOUND = 1,
    CONFIG_READ_ERROR = 2,

    EXECUTABLE_NOTFOUND = 3,
    RESOURCE_NOTFOUND = 4,
    RESOURCE_READ_ERROR = 5,

    // read errors
    MAP_UNDEFINED = 11,
    MIS_UNDEFINED = 12,
    MAP_NOTFOUND = 13,
    MIS_NOTFOUND = 14,
    RULES_NOTFOUND = 15,
    MOD_NOTFOUND = 16,
    MAP_READ_ERROR = 17,
    MIS_READ_ERROR = 18,
    RULES_READ_ERROR = 19,
    MOD_READ_ERROR = 20,

    // modifiy errors
    MOD_ERROR = 21,

    // write errors
    MAP_WRITE_ERROR = 31,
    MIS_WRITE_ERROR = 32,
    RULES_WRITE_ERROR = 33,
    SPAWNER_WRITE_ERROR = 34,

    // search mission errors
    INVALID_DIRECTORY = 41,
    PARTIAL_ERROR = 42,
  }
}
